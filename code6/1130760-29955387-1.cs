    class ListOfItems<T> : CollectionBase, IEnumerable<T> 
    {
        public void Add(T car)
        {
            InnerList.Add(car);
        }
        public void Add(T car, int index)
        {
            InnerList.Insert(index, car);
        }
        public void Remove(int index)
        {
            InnerList.RemoveAt(index);
        }
        public T GetCar(int index)
        {
            return (T)InnerList[index];
        }
        public int Count()
        {
            return InnerList.Count;
        }
        public IEnumerable<T> GetItems()
        {
            return InnerList.Cast<T>();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.GetItems().GetEnumerator();
        }
    }
