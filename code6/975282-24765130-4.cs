    public class myComboBox : mimComboBox
    {
        public myComboBox()
        {
            Items = new object();
            items = new myItems(this);
        }
        new public object Items { get; set; }  // this hides the real Items
        public myItems items { get; set; } // this is the custom property
        public class myItems // this is the custom Items classwith all necessary methods etc..
        {
            public myItems( myComboBox parent )
            {
                parentCB = parent;  // reference to the outer class
            }
            public mimComboBox parentCB { get; set; }  // the man-in-the-middle
            // all your methods..
            new public int Add(object o)  // one example of a custom method
            {
                // add your item-added event here
                return parentCB.items_.Add(o);
            }
            // one of many many properties  to provide..
            public int Count { get { return parentCB.items_.Count; } } 
        }
    }
