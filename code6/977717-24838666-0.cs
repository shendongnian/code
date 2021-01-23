    public static void Main(string[] args)
    {
            List<object> ListToSerialize = new List<object>();
    
            ListToSerialize.Add(new CustomeClass());
            ListToSerialize.Add("");
            ListToSerialize.Add(2);
            ListToSerialize.Add(new int[] { 7, 8, 6 });
    
            XmlSerializer xmlSerializer = new XmlSerializer(ListToSerialize.GetType(), new[] 
            { typeof(int}, typeof(int[]), typeof(string), typeof(CustomeClass) });
    
            StringWriter stringWriter = new StringWriter();
            using (var xmlWriter = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(xmlWriter, ListToSerialize);
            }
            string Res = stringWriter.ToString();
    }
