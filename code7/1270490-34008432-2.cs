    class Program
    {
        public static void Main(string[] args)
        {
            var foo = new FOO();
            var x = new XmlSerializer(typeof(FOO));
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(memoryStream))
                {
                    x.Serialize(writer, foo);
                }
            }
        }
    }
    public class FOO
    {
        public int Money { get; set; }
        public List<FOOTab> Tabs { get; set; }
        public FOO()
        {
            Tabs = new List<FOOTab>();
            Money = 0;
        }
        public class FOOTab
        {
            public List<FOOTabItem> Items { get; set; }
            public FOOTab()
            {
                Items = new List<FOOTabItem>();
            }
        }
        public class FOOTabItem
        {
            public ItemInfo Item { get; set; }
            public int Count { get; set; }
        }
    }
    public class ItemInfo
    {
    }
