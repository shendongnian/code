    public class ComplexType
    {
        public string PropertyName { get; set; }
        public string Layer { get; set; }
        public string DisplayName { get; set; }
    }
    public class DebuggableList : List<ComplexType>
    {
        public ComplexType this[string key]
        {
            get
            {
                return this.FirstOrDefault(i => i.PropertyName == key);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myList= new DebuggableList();
            myList.Add(new ComplexType { DisplayName = "XXX", Layer = "YYY", PropertyName = "ZZZ" });
            myList.Add(new ComplexType { DisplayName = "AAA", Layer = "BBB", PropertyName = "CCC" });
            myList.Add(new ComplexType { DisplayName = "DDD", Layer = "EEE", PropertyName = "FFF" });
        }
    }
