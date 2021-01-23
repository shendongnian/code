    class MyCustomList<T> : List<T>
    {
        public new void Add(T item)
        {
            //your custom Add code here
            // .... now add it..
            base.Add(item);
        }
    }
