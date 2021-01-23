    public class MyRegistry
    {
        Dictionary<string, MyRegistry> _children = new Dictionary<string,MyRegistry>();
    
        public MyRegistry this[string name]
        {
            get { return _items[name]; }
        }
        //notice that an object is returned instead
        public MyRegistry this[int index]
        {
            get { return _items.Values[index]; }
        }
    }
