    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        public abstract class PropertyStateTracker
        {
            private class PropertyDetails
            {
                public object CurrentValue { get; set; }
                public bool HasChanged { get; set; }
                public object OriginalValue { get; set; }
            }
            private readonly Dictionary<string, PropertyDetails> propertyState =
                new Dictionary<string, PropertyDetails>();
            protected TProperty Get<TProperty>(Expression<Func<TProperty>> propertySelector)
            {
                string name = GetNameFromExpression(propertySelector);
                PropertyDetails data;
                if (!propertyState.TryGetValue(name, out data))
                {
                    Set(propertySelector, default(TProperty));
                    return default(TProperty);
                }
                return (TProperty)data.CurrentValue;
            }
            protected void Set<TProperty>(Expression<Func<TProperty>> propertySelector, TProperty value)
            {
                string name = GetNameFromExpression(propertySelector);
                PropertyDetails data;
                if (!propertyState.TryGetValue(name, out data))
                {
                    data = new PropertyDetails() { OriginalValue = value, CurrentValue = value, HasChanged = false };
                    propertyState[name] = data;
                }
                else
                {
                    data.CurrentValue = value;
                    data.HasChanged = true;
                }
            }
            [XmlIgnore]
            public IEnumerable<string> ChangedProperties
            {
                get
                {
                    foreach (var property in propertyState)
                    {
                        if (property.Value.HasChanged)
                        {
                            yield return property.Key;
                        }
                    }
                }
            }
            public bool HasChanged<TProperty>(Expression<Func<TProperty>> propertySelector)
            {
                string name = GetNameFromExpression(propertySelector);
                return HasChanged(name);
            }
            public bool HasChanged(string propertyName)
            {
                EnsurePropertyExists(propertyName);
                PropertyDetails data;
                if (!propertyState.TryGetValue(propertyName, out data))
                {
                    return false;
                }
                return data.HasChanged;
            }
            public TProperty GetOriginalValue<TProperty>(Expression<Func<TProperty>> propertySelector)
            {
                string name = GetNameFromExpression(propertySelector);
                return (TProperty)GetOriginalValue(name);
            }
            public object GetOriginalValue(string propertyName)
            {
                EnsurePropertyExists(propertyName);
                PropertyDetails data;
                if (!propertyState.TryGetValue(propertyName, out data))
                {
                    return GetDefaultValue(GetPropertyInfo(propertyName).PropertyType);
                }
                return data.OriginalValue;
            }
            public TProperty GetCurrentValue<TProperty>(Expression<Func<TProperty>> propertySelector)
            {
                string name = GetNameFromExpression(propertySelector);
                return (TProperty)GetCurrentValue(name);
            }
            public object GetCurrentValue(string propertyName)
            {
                EnsurePropertyExists(propertyName);
                PropertyDetails data;
                if (!propertyState.TryGetValue(propertyName, out data))
                {
                    return GetDefaultValue(GetPropertyInfo(propertyName).PropertyType);
                }
                return data.CurrentValue;
            }
            public void Reset()
            {
                foreach (var property in propertyState)
                {
                    property.Value.OriginalValue = property.Value.CurrentValue;
                    property.Value.HasChanged = false;
                }
            }
            private void EnsurePropertyExists(string propertyName)
            {
                PropertyInfo property = GetPropertyInfo(propertyName);
                if (property == null)
                {
                    throw new ArgumentException(string.Format("A property named '{0}' was not found for type '{1}'",
                        propertyName, this.GetType().Name));
                }
            }
            private PropertyInfo GetPropertyInfo(string propertyName)
            {
                Type type = this.GetType();
                var property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                return property;
            }
            private static object GetDefaultValue(Type t)
            {
                if (t.IsValueType)
                    return Activator.CreateInstance(t);
                return null;
            }
            private static string GetNameFromExpression<TMember>(Expression<Func<TMember>> lambda)
            {
                // check to make sure a non-null lambda was provided.
                if (lambda == null)
                {
                    throw new ArgumentNullException("lambda");
                }
                Expression expression = lambda.Body;
                // is the expression's body a unary expression.
                var unaryExpression = expression as UnaryExpression;
                if (unaryExpression != null && unaryExpression.NodeType == ExpressionType.Convert)
                {
                    expression = unaryExpression.Operand;
                }
                // is the expression's body a parameter expression.
                var parameterExpression = expression as ParameterExpression;
                if (parameterExpression != null)
                {
                    return parameterExpression.Name;
                }
                // is the expression's body a member expression.
                var memberExpression = expression as MemberExpression;
                if (memberExpression != null)
                {
                    return memberExpression.Member.Name;
                }
                // is the expression's body a method call expression.
                var methodCallExpression = expression as MethodCallExpression;
                if (methodCallExpression != null)
                {
                    return methodCallExpression.Method.Name;
                }
                // unable to derive name. throw an exception.
                throw new Exception(
                    string.Format("Failed to derive name from expression '{0}'",
                    expression));
            }
        }
        [XmlRoot("Thing")]
        public class Thing : PropertyStateTracker
        {
            [XmlAttribute("shape")]
            public string Shape
            {
                get { return Get(() => Shape); }
                set { Set(() => Shape, value); }
            }
            [XmlAttribute("color")]
            public string Color
            {
                get { return Get(() => Color); }
                set { Set(() => Color, value); }
            }
        }
        class Program
        {
            private static long count = 0;
            static void Main(string[] args)
            {
                Thing thingInstance;
                System.Xml.Serialization.XmlSerializer serializer = new XmlSerializer(typeof(Thing));
                string rawData = "<Thing shape=\"circle\" color=\"red\"/>";
                using (System.IO.StringReader reader = new System.IO.StringReader(rawData))
                {
                    thingInstance = (Thing)serializer.Deserialize(reader);
                }
                thingInstance.Color = "green";
                // these two variables should be reused every time a new proxy is created. you dont want too many dynamic assemblies.
                var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicThingAssembly"), AssemblyBuilderAccess.Run);
                var moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicThingModule");
                // TODO: need to figure out a way to reuse the proxyTypes being generated or you will have a 
                // memory leak. the type is unique based on the properties that have been modified, so you should be able to use 
                // the state stored inside of thingInstance to figure this out. I leave this up to you to implement.
                Type proxyType = CreateProxy(moduleBuilder, thingInstance);
                var proxy = Activator.CreateInstance(proxyType);
                foreach (var propertyName in thingInstance.ChangedProperties)
                {
                    proxyType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                        .SetValue(proxy, thingInstance.GetCurrentValue(propertyName));
                    proxyType.GetProperty("O_" + propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                        .SetValue(proxy, thingInstance.GetOriginalValue(propertyName));
                }
                // Important this XmlSerializer should be cached, otherwise you will have a memory leak in your program.
                System.Xml.Serialization.XmlSerializer serializer2 = new XmlSerializer(proxyType, new XmlRootAttribute("Thing"));
                StringBuilder sb = new StringBuilder();
                using (System.IO.StringWriter writer = new System.IO.StringWriter(sb))
                {
                    serializer2.Serialize(writer, proxy);
                }
                Console.Write(sb.ToString());
            }
            private static Type CreateProxy(ModuleBuilder moduleBuilder, Thing thing)
            {
                var typeName = "DynamicType" + System.Threading.Interlocked.Increment(ref count).ToString("X5");
                TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public);
                Type t = typeof(Thing);
                foreach (var propertyName in thing.ChangedProperties)
                {
                    var propertyInfo = t.GetProperty(propertyName,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    CreateProperty(typeBuilder, propertyInfo.Name, propertyInfo.PropertyType);
                    CreateProperty(typeBuilder, "O_" + propertyInfo.Name, propertyInfo.PropertyType);
                }
                return typeBuilder.CreateType();
            }
            private static void CreateProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
            {
                var fieldBuilder = typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
                // The last argument of DefineProperty is null, because the
                // property has no parameters. (If you don't specify null, you must
                // specify an array of Type objects. For a parameterless property,
                // use an array with no elements: new Type[] {})
                var propertyBuilder = typeBuilder.DefineProperty(
                    propertyName, PropertyAttributes.HasDefault, propertyType, null);
                var attributeConstructor = typeof(XmlAttributeAttribute).GetConstructor(new Type[] { typeof(string) });
                propertyBuilder.SetCustomAttribute(
                    new CustomAttributeBuilder(
                        attributeConstructor,
                        new object[] { propertyName.ToLower() }));
                // The property set and property get methods require a special
                // set of attributes.
                MethodAttributes getSetAttr =
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
                MethodBuilder getPropertyMethodBuilder =
                    typeBuilder.DefineMethod("get_" + propertyName,
                                      getSetAttr,
                                      propertyType,
                                      Type.EmptyTypes);
                // Create the get methods body.
                ILGenerator getPropertyMethodILGenerator = getPropertyMethodBuilder.GetILGenerator();
                getPropertyMethodILGenerator.Emit(OpCodes.Ldarg_0);
                getPropertyMethodILGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
                getPropertyMethodILGenerator.Emit(OpCodes.Ret);
                // Define the "set" accessor method for CustomerName.
                MethodBuilder setPropertyMethodBuilder =
                    typeBuilder.DefineMethod("set_" + propertyName,
                                               getSetAttr,
                                               null,
                                               new Type[] { propertyType });
                // Create the set methods body.
                ILGenerator setPropertyMethodILGenerator = setPropertyMethodBuilder.GetILGenerator();
                setPropertyMethodILGenerator.Emit(OpCodes.Ldarg_0);
                setPropertyMethodILGenerator.Emit(OpCodes.Ldarg_1);
                setPropertyMethodILGenerator.Emit(OpCodes.Stfld, fieldBuilder);
                setPropertyMethodILGenerator.Emit(OpCodes.Ret);
                // Last, we must map the two methods created above to our PropertyBuilder to 
                // their corresponding behaviors, "get" and "set" respectively. 
                propertyBuilder.SetGetMethod(getPropertyMethodBuilder);
                propertyBuilder.SetSetMethod(setPropertyMethodBuilder);
            }
        }
    }
