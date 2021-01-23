    public class TestClass : SomeFancyInheritedObject 
    { 
        public static void Test() {
            FOO.FOOTabItem bar = new FOO.FOOTabItem();
            bar.Count = 100; // This is now accessible
        }
    }
    public class FOO {
        public int Money { get; set; }
        public List<FOOTab> Tabs { get; set; }
        public FOO() {
            Tabs = new List<FOOTab>();
            Money = 0;
        }
    
        public struct FOOTab {
            public List<FOOTabItem> Items { get; set; }
            public FOOTab()
            {
                Items = new List<FOOTabItem>();
            }
        }
    
        public struct FOOTabItem {
            public ItemInfo Item { get; set; }
            public int Count { get; set; }
        }
    }
