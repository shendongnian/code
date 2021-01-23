    public class MyClass
    {
        private MyCollection myCollection = new MyCollection();
        public IList<MyElement> Collection { get { return myCollection; } }
    }
    internal class MyCollection: Collection<MyElement>
    {
        // by overriding InsertItem you can control Add and Insert
        protected override InsertItem(int index, MyElement item)
        {
            if (CheckItem(item))
                base.InsertItem(index, item);
            throw new ArgumentException("blah");
        }
        // similarly, you can override RemoveItem to control Remove and RemoveAt,
        // and SetItem to control the setting by the indexer (this[])
    }
