    static void Main()
    {
        myType item = new myType();
    
        var button = new Button();
        myType.button = button;
    
        var list = new ListBox();
        myType.list = list;
    
        item = list.GetParent();
        bool isSameButton = button == item.button;
        bool isSameList = list == item.list;
    
        Assert.IsTrue(isSameButton);
        Assert.IsTrue(isSameList);
    }
    
    public class myType
    {
        private RadioButton _button;
        public RadioButton button
        {
            get { return _button; }
            set {
                    value.AssociateParent(this);
                    _button = value;
                }
        }
    
        private ListBox _list;
        public ListBox list
        {
            get { return _list; }
            set {
                    value.AssociateParent(this);
                    _list= value;
                }
        }
    }
    
    public static class Extensions
    {
        private static Dictionary<object, object> Items { get; set; }
    
        static Extensions()
        {
            Items = new Dictionary<object, object>();
        }
    
        public static void AssociateParent(this object child, object parent)
        {
            Items[child] = parent;
        }
    
        public static object GetParent(this object child)
        {
            if (Items.ContainsKey(child)) return Items[child];
            return null;
        }
    }
