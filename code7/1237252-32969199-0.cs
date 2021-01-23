    class History<T>
    {
        Queue<T> data;
        int maxCapacity;
        public History(int maxCapacity) 
        {
            this.maxCapacity = maxCapacity; 
            data = new Queue<T>(maxCapacity);
        }
        public void AddEntry(T newData)
        {
            if (data.Count >= maxCapacity)
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
