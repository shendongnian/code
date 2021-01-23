    [Serializable]
    public class Foo
    {
        public IList<int> Numbers { get; set; }
        public string TheNumber { get; set; }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            var attributes = new XmlAttributes
            {
                XmlIgnore = true
            };
            var overrides = new XmlAttributeOverrides();
            overrides.Add(typeof(Foo), "Numbers", attributes);
            var serializer = new XmlSerializer(typeof(Foo), overrides);
            // the rest of this is for demo purposes.  
            // the code above is whats important
            //
            using (var ms = new MemoryStream())
            using (var reader = new StreamReader(ms))
            {
                serializer.Serialize(ms, new Foo() { TheNumber = "5" });    
                ms.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                Debug.WriteLine(reader.ReadToEnd());
            }
            
        }
    }
