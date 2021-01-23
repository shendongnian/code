    public static class DataContractSerializerHelper
    {
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
        public static string GetXml<T>(T obj, DataContractSerializer serializer) where T : class
        {
            using (var textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    "; // The indentation used in the test string.
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.WriteObject(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
        public static string GetXml<T>(T obj) where T : class
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            return GetXml(obj, serializer);
        }
    }
    public static class SurrogateTest
    {
        public static void Test()
        {
            Student kid = new Student();
            kid.Id = Guid.NewGuid();
            kid.FirstName = "foo";
            kid.LastName = "bar";
            DataContractSerializer dcs = new DataContractSerializer(
                typeof(Student),
                new Type [] { typeof(StudentId) },
                Int32.MaxValue,
                false, true, new StudentSurrogate());
            SerializationFlags.StudentGuidOnly = false;
            string xml1 = DataContractSerializerHelper.GetXml(kid, dcs);
            SerializationFlags.StudentGuidOnly = true;
            string xml2 = DataContractSerializerHelper.GetXml(kid, dcs);
         }
    }
