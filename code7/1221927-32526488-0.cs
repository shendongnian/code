    public class ItemBase
    {
        protected ItemBase()
        {
        }
        public void PublicMethod() { }
        public int PublicProperty { get; set; }
    }
    public class Factory
    {
        private class PrivateItemBase : ItemBase
        {
            public void PrivateMethod() { }
            public int PrivateProperty { get; set; }
        }
        public Factory(int id)
        {
        }
        public IEnumerable<ItemBase> Items { get; private set; }
        public ItemBase CreateItem()
        {
            PrivateItemBase rValue = new PrivateItemBase();
            rValue.PrivateMethod();
            rValue.PrivateProperty = 4;
            return rValue;
        }
    }
