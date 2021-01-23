    public class AdapterCompiler
    {
        public AdapterFactory<T> DefineAdapter<T>(Type targetType)
        {
            return DefineAdapter<T>(targetType, null);
        }
        public AdapterFactory<T> DefineAdapter<T>(Type targetType, string outputFile)
        {
            Type abstractType = typeof(T);
            AssemblyBuilder ab = null;
            // Get the TypeBuilder for the new class
            TypeBuilder tb = GetTypeBuilder(abstractType, out ab, outputFile);
            
            // Make a field for the target type within the new class
            FieldBuilder fb = DefineTargetObjectField(tb, targetType);
            // Map the abstract methods onto the target type
            DefineAbstractMethods(tb, fb, abstractType, targetType);
            // make a constructor that can vector out to the target type
            DefineConstructor(tb, fb, abstractType, targetType);
            // build the class
            Type adaptedType = tb.CreateType();
            if (outputFile != null)
                ab.Save(outputFile);
            // Make a factory object for building the class
            return new AdapterFactory<T>(adaptedType, targetType);
        }
        private string GetTargetObjectFieldName(Type targetType)
        {
            // create a consistent name mangled field name
            return "_f" + targetType.Name;
        }
        private FieldBuilder DefineTargetObjectField(TypeBuilder tb, Type targetType)
        {
            // Define the actual field
            return tb.DefineField(GetTargetObjectFieldName(targetType), targetType, FieldAttributes.Private);
        }
        private TypeBuilder GetTypeBuilder(Type abstractType, out AssemblyBuilder assemblyBuilder, string outputFile)
        {
            // make an assembly builder, module builder and type builder.
            // we only need the AssemblyBuilder and TypeBuilder
            AssemblyName assemName = new AssemblyName("Assembly" + abstractType.Name);
            assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemName,
                outputFile != null ? AssemblyBuilderAccess.RunAndSave : AssemblyBuilderAccess.Run);
            ModuleBuilder mb = outputFile != null ?
                assemblyBuilder.DefineDynamicModule(assemName.Name, outputFile) :
                assemblyBuilder.DefineDynamicModule(assemName.Name);
            TypeBuilder tb = mb.DefineType("Wrapped"+abstractType.Name, abstractType.Attributes & ~(TypeAttributes.Abstract), abstractType);
            return tb;
        }
        private void DefineAbstractMethods(TypeBuilder tb, FieldBuilder fb, Type abstractType, Type targetType)
        {
            // we need to pass along a list of already defined fields
            List<string> definedProperties = new List<string>();
            // get the abstract methods - tricky - use a lambda expression to filter via LINQ
            IEnumerable<MethodInfo> methods = abstractType.GetMethods().Where(mi => mi.IsAbstract);
            foreach (MethodInfo mi in methods)
            {
                DefineAbstractMethod(tb, fb, mi, targetType, definedProperties);
            }
        }
        private Type[] GetParameterTypes(MethodInfo mi)
        {
            // given a method, get a list of the types of its parameters
            ParameterInfo[] pi = mi.GetParameters();
            Type[] types = new Type[pi.Length];
            for (int i = 0; i < pi.Length; i++)
            {
                types[i] = pi[i].ParameterType;
            }
            return types;
        }
        private Type[] GetParameterTypes(PropertyInfo propi)
        {
            // given a property, get a list of the types of its parameters
            ParameterInfo[] pi = propi.GetIndexParameters();
            Type[] types = new Type[pi.Length];
            for (int i = 0; i < pi.Length; i++)
            {
                types[i] = pi[i].ParameterType;
            }
            return types;
        }
        private void VerifyParameterMatch(string methodName, Type[] source, Type[] dest)
        {
            // type match parameters for one method to another
            if (source.Length != dest.Length)
            {
                throw new Exception("In method " + methodName + ", parameter list length for wrapper and target object differ.");
            }
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != dest[i])
                {
                    throw new Exception("In method " + methodName + ", expected parameter " + i + " to be type " + dest[i].Name + ", but found " +
                        source[i].Name + ".");
                }
            }
        }
        private void DefineAbstractMethod(TypeBuilder tb, FieldBuilder fb, MethodInfo mi, Type targetType, List<string> definedProperties)
        {
            // map the abstract method from one class into the concrete implementation in another
            Type[] parameterTypes = GetParameterTypes(mi);
            // get the target method
            MethodInfo targetMethod = targetType.GetMethod(mi.Name, parameterTypes);
            if (targetMethod == null)
                throw new Exception("Unable to find matching method for " + mi.Name + " in class " + targetType.Name);
            // get the target method's parameter types
            Type[] targetParameterTypes = GetParameterTypes(targetMethod);
            // Ensure that they match, throw on failure
            VerifyParameterMatch(mi.Name, parameterTypes, targetParameterTypes);
            MethodAttributes attrs = MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.ReuseSlot;
            // IsSpecialName is equivalent to "implementation of a property"
            if (mi.IsSpecialName)
            {
                attrs = attrs | MethodAttributes.SpecialName;
                // we only really handle get_/set_ properties
                if (mi.Name.StartsWith("get_") || mi.Name.StartsWith("set_"))
                {
                    string propName = mi.Name.Substring(4);
                    if (!definedProperties.Contains(propName))
                    {
                        definedProperties.Add(propName);
                        PropertyInfo pi = mi.DeclaringType.GetProperty(propName);
                        tb.DefineProperty(propName, pi.Attributes, pi.PropertyType, GetParameterTypes(pi));
                    }
                }
            }
            // define the method
            MethodBuilder mb = tb.DefineMethod(mi.Name, attrs, mi.ReturnType, parameterTypes);
         
            ILGenerator gen = mb.GetILGenerator();
            // fetch the target object
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldfld, fb);
            // pass all of our parameters on
            for (int i = 0; i < parameterTypes.Length; i++)
            {
                gen.Emit(OpCodes.Ldarg, i + 1);
            }
            // call the method, virtually or otherwise
            gen.Emit(targetMethod.IsVirtual ? OpCodes.Callvirt : OpCodes.Call, targetMethod);
            gen.Emit(OpCodes.Ret);
        }
        private void DefineConstructor(TypeBuilder tb, FieldBuilder fb, Type abstractType, Type targetType)
        {
            // define a construct of the form:
            // .ctor(Type targetObjectType, Type[] constructorArgumentTypes, object[] constructorArguments)
            //
            // This implementation is effectively:
            // ConstructorInfo ci = targetObjectType.GetConstructor(constructorArgumentTypes)
            // _ftargetType = ci.Invoke(constructorArguments)
            //
            ConstructorBuilder cb = tb.DefineConstructor(MethodAttributes.Public,
                CallingConventions.Standard,
                new Type[] { typeof(Type), typeof(Type[]), typeof(object[]) });
            ILGenerator gen = cb.GetILGenerator();
            // see if there is a default constructor in the abstract type
            ConstructorInfo ci = abstractType.GetConstructor(Type.EmptyTypes);
            if (ci == null)
            {
                // if not, get Object contructor
                Type objectType = typeof(object);
                ci = objectType.GetConstructor(Type.EmptyTypes);
            }
            // call base class constructor
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Call, ci);
            // needed later
            gen.Emit(OpCodes.Ldarg_0);
            // get the constructor from targetObjectType
            gen.Emit(OpCodes.Ldarg_1);
            gen.Emit(OpCodes.Ldarg_2); 
            MethodInfo mi = typeof(Type).GetMethod("GetConstructor", new Type[] { typeof(Type[]) });
            gen.Emit(OpCodes.Callvirt, mi);
            // stack is now:
            // 0: this
            // 1: constuctor info
            // invoke the constructor on the arguments
            gen.Emit(OpCodes.Ldarg_3);
            mi = typeof(ConstructorInfo).GetMethod("Invoke", new Type[] { typeof(object[]) });
            gen.Emit(OpCodes.Callvirt, mi);
            // store into _ftargetType
            gen.Emit(OpCodes.Stfld, fb);
            gen.Emit(OpCodes.Ret);
        }
    }
