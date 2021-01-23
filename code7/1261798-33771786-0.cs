        public int itemInt { get; set; }
        
        public string itemString { get; set; }
        public TestItem() { }
        
        public TestItem(int _intVal, string _stringVal)
        {
            itemInt = _intVal;
            itemString = _stringVal;
        }
    }
    public class Testmain
    {
        
       public int mainInt { get; set; }
        
        public string mainString { get; set; }
        
        public List<TestItem> TestItem = new List<TestItem>();
    }
