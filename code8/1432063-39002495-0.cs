        public List<T> oldItems = new List<T>();
        public List<T> newItems = new List<T>();
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
            oldItems.Add(value);
        }
            
    }
