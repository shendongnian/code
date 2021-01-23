    [XmlRoot(ElementName = "FooContainer")]
    public class FooContainer : List<SomeGenericClassBase>
    {
        [XmlAttribute]
        public string FooName { get; set; }
    }    
    
    [XmlInclude(typeof(SomeGenericClass<string>))]
    [XmlInclude(typeof(SomeGenericClass<int>))]
    public abstract class SomeGenericClassBase
    {
        [XmlAttribute]
        public string Name { get; set; }
    
        [XmlAttribute]
        public string Description { get; set; }
    }
        
    public class SomeGenericClass<T> : SomeGenericClassBase
    {
        [XmlAttribute]
        public T Value { get; set; }
    
        [XmlElement]
        public T[] ValidOptions { get; set; }
    }
    
    class Class1
    {
        public static void Run()
        {
            var f = new FooContainer()
            {
                new SomeGenericClass<string> {  Name = "firstParam", Description = "First Paramater Serialized", Value = "Foobar"},
                new SomeGenericClass<int>  {  Name = "nextParam", Description = "Second Serialized parameter",  Value = 10000 }
            };
    
            f.FooName = "DoSomething";
    
            XmlSerializer serializer = new XmlSerializer(f.GetType());            
            StringBuilder sb = new StringBuilder();
    
            // Serialize
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, f);
            }
    
            Console.WriteLine(sb);
    
            // Deserialize
            using(StringReader reader = new StringReader(sb.ToString()))
            {
                FooContainer f2 = (FooContainer)serializer.Deserialize(reader);
            }
        }
    }
