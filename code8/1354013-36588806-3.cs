    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load("D:\\TestXML.xml");
                var Deserializer = DeserializeXml<root>(xmlDoc.DocumentElement.OuterXml);
                int count = Deserializer.record.field.Split('�').Length - 1;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public static T DeserializeXml<T>(string xml)
        {
            T result;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }
    }
