    using ProtoField = System.Tuple<string, Type>; 
    public static class ProtoTypeBuilder
    {
        public static Type CompileResultType(string typeName, IEnumerable<ProtoField>> fields)
        {
            TypeBuilder tb = GetTypeBuilder(typeName);
            ConstructorBuilder constructor =
                tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName |
                                            MethodAttributes.RTSpecialName);
            ConstructorInfo contractInfoCon =
                typeof (ProtoBuf.ProtoContractAttribute).GetConstructor(Array.Empty<Type>());
            CustomAttributeBuilder cab = new CustomAttributeBuilder(contractInfoCon, Array.Empty<object>());
            tb.SetCustomAttribute(cab);
            foreach (var field in fields.Select((x, i) => new {Item = x, Index = i + 1}))
                CreateProperty(tb, field.Item.Item1, field.Item.Item2, field.Index);
            Type objectType = tb.CreateType();
            return objectType;
        }
        private static TypeBuilder GetTypeBuilder(string typeName)
        {
            var typeSignature = "DynamicProtoTypes";
            var an = new AssemblyName(typeSignature);
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an,
                AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            TypeBuilder tb = moduleBuilder.DefineType(typeName
                , TypeAttributes.Public |
                  TypeAttributes.Class |
                  TypeAttributes.AutoClass |
                  TypeAttributes.AnsiClass |
                  TypeAttributes.BeforeFieldInit |
                  TypeAttributes.AutoLayout
                , null);
            return tb;
        }
        private static void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType, int protoTag)
        {
            FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
            PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault,
                propertyType, null);
            MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName,
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType,
                Type.EmptyTypes);
            ILGenerator getIl = getPropMthdBldr.GetILGenerator();
            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);
            MethodBuilder setPropMthdBldr =
                tb.DefineMethod("set_" + propertyName,
                    MethodAttributes.Public |
                    MethodAttributes.SpecialName |
                    MethodAttributes.HideBySig,
                    null, new[] {propertyType});
            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();
            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);
            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);
            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
            ConstructorInfo contractInfoCon = typeof (ProtoBuf.ProtoMemberAttribute).GetConstructor(new[] {typeof (int)});
            CustomAttributeBuilder cab = new CustomAttributeBuilder(contractInfoCon, new object[] {protoTag});
            propertyBuilder.SetCustomAttribute(cab);
        }
    }
