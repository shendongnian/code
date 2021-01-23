    class Program
    {
        static void Main(string[] args)
        {
            var s = Serialize(new BackgroundJobInfo() { Password = "toto", Text = "text" });
            var myJob = Deserialize(s);
        }
        public static string Serialize(BackgroundJobInfo info)
        {
            MySurrogate mySurrogate = new MySurrogate();
            DataContractSerializer dataContractSerializer =
                new DataContractSerializer(
                typeof(BackgroundJobInfo),
                null,
                64 * 1024,
                true,
                true,
                mySurrogate);
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            {
                var writer = new XmlTextWriter(stringWriter);
                dataContractSerializer.WriteObject(writer, info);
            }
            return stringBuilder.ToString();
        }
        public static BackgroundJobInfo Deserialize(string info)
        {
            var dataContractSerializer = new DataContractSerializer(typeof(BackgroundJobInfo));
            using (var xmlTextReader = new XmlTextReader(info, XmlNodeType.Document, new XmlParserContext(null, null, null, XmlSpace.None)))
            {
                try
                {
                    var result = (BackgroundJobInfo)dataContractSerializer.ReadObject(xmlTextReader);
                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
    internal class MySurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            return typeof (BackgroundJobInfo);
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            var maskedMembers = obj.GetType().GetProperties().Where(
                m => m.GetCustomAttributes(typeof(DataMemberAttribute), true).Any()
                && m.GetCustomAttributes(typeof(DoNotSerializeAttribute), true).Any());
            foreach (var member in maskedMembers)
            {
                member.SetValue(obj, null, null);
            }
            return obj;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            throw new NotImplementedException();
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
            throw new NotImplementedException();
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }
        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }
    }
    internal class DoNotSerializeAttribute : Attribute
    {
    }
    [DataContract]
    public class BackgroundJobInfo
    {
        [DataMember(Name = "password")]
        [DoNotSerializeAttribute]
        public string Password { get; set; }
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
