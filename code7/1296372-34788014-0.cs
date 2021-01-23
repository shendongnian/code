    public class Type1
    {
        public string Name { get; set; }
        public Type1() { }
    }
    public class Type2
    {
        public string Name { get; set; }
        public Type2() { }
    }
    
    //....
    
    List<object> list = new List<object>();
    list.Add(new Type1() { Name = "Name1" });
    list.Add(new Type2() { Name = "Name2" });
     XmlSerializer serializer = new XmlSerializer(typeof(List<object>), new Type[] { typeof(Type1), typeof(Type2) });
     using (TextWriter writer = new StreamWriter("result.xml"))
     {
         serializer.Serialize(writer, list);
     }
