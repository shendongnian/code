    internal class SerializationTypeResolver : DataContractResolver {
        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace) {
            // not necessary to hardcode some type name of course, you can use some broader condition
            // like if type belongs to another assembly
            if (type.Name == "SecondData") {
                XmlDictionary dictionary = new XmlDictionary();
                // use assembly qualified name
                typeName = dictionary.Add(type.AssemblyQualifiedName);
                typeNamespace = dictionary.Add("http://tempuri.org"); // some namespace, does not really matter in this case
                return true;
            }
            return knownTypeResolver.TryResolveType(type, declaredType, null, out typeName, out typeNamespace);
        }
        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver) {
            if (typeNamespace == "http://tempuri.org") {
                return Type.GetType(typeName); // assembly qualified already
            }
            return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null);
        }
    }
