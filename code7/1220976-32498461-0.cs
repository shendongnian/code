    public class Item
    {
        private List<Item> _containerList;
        public Item(List<Item> containerList)
        {
            _containerList = containerList;
        }
        public int InstanceNumber
        {
            get { return _containerList.IndexOf(this); }
        }
    }
