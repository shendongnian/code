    public class MyTreeViewItem :TreeViewItem
    {
        private int _index;
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
    
        public MyTreeViewItem() : base() 
        {
          
        }
    }
