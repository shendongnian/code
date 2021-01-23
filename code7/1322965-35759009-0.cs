     public class PropertyManager : DynamicObject
        {
            private static Dictionary<Type, Dictionary<string, GetterAndSetter>> _compiledProperties = new Dictionary<Type, Dictionary<string, GetterAndSetter>>();
    
            private static Object _compiledPropertiesLockObject = new object();
    
            private class GetterAndSetter
            {
                public Action<object, Object> Setter { get; set; }
    
                public Func<Object, Object> Getter { get; set; }
            }
    
            private Object _object;
    
            private Type _objectType;
    
            private PropertyManager(Object o)
            {
                _object = o;
                _objectType = o.GetType();
            }
    
            public static dynamic Wrap(Object o)
            {
                if (o == null)
                    return null; // null reference will be thrown
    
                var type = o.GetType();
    
                EnsurePropertySettersAndGettersForType(type);
    
                return new PropertyManager(o) as dynamic;
            }
    
            private static void EnsurePropertySettersAndGettersForType(Type type)
            {
                if (false == _compiledProperties.ContainsKey(type))
                    lock (_compiledPropertiesLockObject)
                        if (false == _compiledProperties.ContainsKey(type))
                        {
                            Dictionary<string, GetterAndSetter> _getterAndSetters;
                            _compiledProperties[type] = _getterAndSetters = new Dictionary<string, GetterAndSetter>();
    
                            var properties = type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
    
                            foreach (var property in properties)
                            {
                                var getterAndSetter = new GetterAndSetter();
                                _getterAndSetters[property.Name] = getterAndSetter;
    
                                // burn getter and setter
    
                                if (property.CanRead)
                                {
                                    // burn getter
    
                                    var param = Expression.Parameter(typeof(object), "param");
    
                                    Expression propExpression = Expression.Convert(Expression.Property(Expression.Convert(param, type), property), typeof(object));
    
                                    var lambda = Expression.Lambda(propExpression, new[] { param });
    
                                    var compiled = lambda.Compile() as Func<object, object>;
                                    getterAndSetter.Getter = compiled;
                                }
    
                                if (property.CanWrite)
                                {
                                    var thisParam = Expression.Parameter(typeof(Object), "this");
                                    var theValue = Expression.Parameter(typeof(Object), "value");
    
                                    var isValueType = property.PropertyType.IsClass == false && property.PropertyType.IsInterface == false;
    
                                    Expression valueExpression;
                                    if (isValueType)
                                        valueExpression = Expression.Unbox(theValue, property.PropertyType);
                                    else
                                        valueExpression = Expression.Convert(theValue, property.PropertyType);
    
                                    var thisExpression = Expression.Property (Expression.Convert(thisParam, type), property);
    
    
                                    Expression body = Expression.Assign(thisExpression, valueExpression);
    
                                    var block = Expression.Block(new[]
                                    {
                                        body,
                                        Expression.Empty ()
                                    });
    
                                    var lambda = Expression.Lambda(block, thisParam, theValue);
    
                                    getterAndSetter.Setter = lambda.Compile() as Action<Object, Object>;
                                }
                            }
                        }
            }
    
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var memberName = binder.Name;
                result = null;
                Dictionary<string, GetterAndSetter> dict;
                GetterAndSetter getterAndSetter;
                if (false == _compiledProperties.TryGetValue(_objectType, out dict)
                    || false == dict.TryGetValue(memberName, out getterAndSetter))
                {
                    return false;
                }
    
                if (getterAndSetter.Getter == null)
                    throw new NotSupportedException("The property has no getter!");
    
                result = getterAndSetter.Getter(_object);
                return true;
            }
    
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                var memberName = binder.Name;
                
                Dictionary<string, GetterAndSetter> dict;
                GetterAndSetter getterAndSetter;
                if (false == _compiledProperties.TryGetValue(_objectType, out dict)
                    || false == dict.TryGetValue(memberName, out getterAndSetter))
                {
                    return false;
                }
    
                if (getterAndSetter.Setter == null)
                    throw new NotSupportedException("The property has no getter!");
    
                getterAndSetter.Setter(_object, value);
    
                return true;
            }
        }
 
