    public class StudentSurrogate : IDataContractSurrogate
    {
        #region IDataContractSurrogate Members
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(Student) && SerializationFlags.StudentGuidOnly)
            {
                return typeof(StudentId);
            }
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            throw new NotImplementedException();
        }
        public void GetKnownCustomDataTypes(System.Collections.ObjectModel.Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj != null)
            {
                var type = obj.GetType();
                if (type == typeof(Student) && SerializationFlags.StudentGuidOnly)
                {
                    var surrogate = new StudentId
                    {
                        Id = ((Student)obj).Id,
                    };
                    return surrogate;
                }
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
