    public class TwoEndedList<T> : IList<T>
    {
        private readonly List<T> front = new List<T>();
        private readonly List<T> back = new List<T>();
        public void Add(T item)
        {
            back.Add(item);
        }
        public void Insert(int index, T item)
        {
            if (index == 0)
                front.Add(item);
            else if (index < front.Count)
                front.Insert(front.Count - index, item);
            else
                back.Insert(index - front.Count, item);
        }
        // rest of implementation
    }
