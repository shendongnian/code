    Public class MyList<T> : List<T>
    {
        private List<T> oldItems = new List<T>();
        private List<T> newItems = new List<T>();
        private List<T> items = new List<T>();
        public List<T> Items 
        {
            get { return items; }
            set { items = value; }
        }
        public void Add(T value)
        {
            Items.Add(value);
            newItems.Add(Items.Where(w=>w==value)); // must be the object in the "Items" list
        }
        public void Remove(T value)
        {
            Items.Remove(value);
            oldItems.Add(value); //value does not exist anymore in `Items`
        }
            
        public List<T> GetOldItems()
        {
            List<T> oldi = oldItems;
            oldItems.Clear();
            return oldi;
        }
            
        public List<T> GetNewItems() //
        {
            List<T> newi = newItems;
            newItems.Clear();
            return newi;
        }
    }
