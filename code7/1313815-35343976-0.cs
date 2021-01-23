    class Program
        {
            static void Main(string[] args)
            {          
                SerializationHelper.SerializeTest();
                Console.Read();
            }
        }
    
        public static class SerializationHelper
        {
            [Serializable]
            public class ClassA
            {
                public string Name;
                public string Address;
                public string Details;
    
                public List<string> PhoneNumbers = new List<string>();
    
                public bool ShouldSerializePhoneNumbers()
                {
                    if (PhoneNumbers == null || PhoneNumbers.Count <= 0)
                        return false;
                    else
                        return true;
                }
            }
    
            public static void SerializeTest()
            {
                ClassA call = new ClassA();
                call.Name = "Praveen";
    
                XmlSerializer ser = new XmlSerializer(typeof(ClassA));
    
                TextWriter writer = new StringWriter();
                ser.Serialize(writer, call);
    
                string xml = writer.ToString();
            }
        }
