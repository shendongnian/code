    class Foo
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof (Foo);
            var value = "[{\"Id\":5, \"Data\":5},{\"Id\":5, \"Data\":5},{\"Id\":5, \"Data\":5}]";
            var list = DeserializeList(value,type);
            var myFooList = list as List<Foo>;
        }
        private static object DeserializeList( string value,Type type)
        {
            var listType = typeof (List<>).MakeGenericType(type);
            var list = JsonConvert.DeserializeObject(value, listType);
            return list;
        }
    }
