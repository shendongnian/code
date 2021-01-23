    public class CursorDataSurrogate : IDataContractSurrogate
    {
        [DataContract(Namespace = "")]
        class CursorName
        {
            [DataMember]
            public string Name { get; set; }
        }
        #region IDataContractSurrogate Members
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(System.Windows.Input.Cursor))
                return typeof(CursorName);
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj is CursorName)
            {
                try
                {
                    return (System.Windows.Input.Cursor)TypeDescriptor.GetConverter(typeof(System.Windows.Input.Cursor)).ConvertFromInvariantString(((CursorName)obj).Name);
                }
                catch (Exception ex)
                {
                    // ArgumentException or Win32Exception could be generated if file is missing or name is invalid.  Handle here, or pass on?
                    throw;
                }
            }
            return obj;
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is System.Windows.Input.Cursor)
            {
                return new CursorName { Name = TypeDescriptor.GetConverter(typeof(System.Windows.Input.Cursor)).ConvertToInvariantString(obj) };
            }
            return obj;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
