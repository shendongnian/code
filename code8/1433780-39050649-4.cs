    public class AddItemEventArgs<T> : EventArgs
    {
        public T Item { get; private set; }
        public AddItemEventArgs(T item)
        {
            Item = item;
        }
    }
    public class Class1
    {
        public EventHandler<AddItemEventArgs<string>> AddItem;
        public BindingList<string> BindingList { get; set; }
        public Class1()
        {
            // Sorry, old-style because I'm not using C# 6 yet
            BindingList = new BindingList<string>();
        }
        // For testing, I prefer unique list items
        private int _index;
        public void Add()
        {
            var th = new Thread(() =>
            {
                string item = (++_index).ToString();
                OnAddItem(item);
            }) { IsBackground = true };
            th.Start();
        }
        public void Remove()
        {
            if (BindingList.Count > 1)
            {
                BindingList.RemoveAt(0);
            }
        }
        private void OnAddItem(string item)
        {
            EventHandler<AddItemEventArgs<string>> handler = AddItem;
            if (handler != null)
            {
                handler(this, new AddItemEventArgs<string>(item));
            }
        }
    }
