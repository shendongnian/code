    class History<T>
    {
        Queue<T> data;
        public int MaxCapacity { get; private set; }
        public History(int maxCapacity) 
        {
            MaxCapacity = maxCapacity; 
            data = new Queue<T>(maxCapacity);
        }
        public void AddEntry(T newData)
        {
            if (data.Count >= MaxCapacity)
            {
                data.Dequeue();
            }
            data.Enqueue(newData);
        }
        public T Peek()
        {
            return data.Peek();
        }
    }
