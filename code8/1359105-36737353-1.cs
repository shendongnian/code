    static void Main(string[] args)
        {
            var o = JsonConvert.DeserializeObject<RootObject>(json).field2;// list - count = 2
        }
    public class Field2
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class RootObject
    {
        public string field1 { get; set; }
        public List<Field2> field2 { get; set; }
    }
