    class MyDataContractSurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(MyResource))
            {
                return typeof(Dictionary<string, object>);
            }
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj.GetType() == typeof(Dictionary<string, object>) && 
                targetType == typeof(MyResource))
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)obj;
                MyResource mr = new MyResource();
                foreach (PropertyInfo prop in GetInterestingProperties(typeof(MyResource)))
                {
                    DataMemberAttribute att = prop.GetCustomAttribute<DataMemberAttribute>();
                    object value;
                    if (dict.TryGetValue(att.Name, out value))
                    {
                        prop.SetValue(mr, value);
                        dict.Remove(prop.Name);
                    }
                }
                // should only be one property left in the dictionary
                if (dict.Count > 0)
                {
                    var kvp = dict.First();
                    mr.SpecialName = kvp.Key;
                    mr.SpecialValue = (string)kvp.Value;
                }
                return mr;
            }
            return obj;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj.GetType() == typeof(MyResource) && 
                targetType == typeof(Dictionary<string, object>))
            {
                MyResource mr = (MyResource)obj;
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add(mr.SpecialName, mr.SpecialValue);
                foreach (PropertyInfo prop in GetInterestingProperties(typeof(MyResource)))
                {
                    DataMemberAttribute att = prop.GetCustomAttribute<DataMemberAttribute>();
                    dict.Add(att.Name, prop.GetValue(mr));
                }
                return dict;
            }
            return obj;
        }
        private IEnumerable<PropertyInfo> GetInterestingProperties(Type type)
        {
            return type.GetProperties().Where(p => p.CanRead && p.CanWrite &&
                           p.GetCustomAttribute<DataMemberAttribute>() != null);
        }
        // ------- The rest of these methods are not needed -------
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public void GetKnownCustomDataTypes(System.Collections.ObjectModel.Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }
    }
