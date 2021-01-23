    internal class GenericList<T>  where T : IComparable
    {
        private T[] _genericList;
        private int _count;
        private int _listInnitialLength;
        public GenericList(int listLength)
        {
            _genericList = new T[listLength];
            _count = 0;
            _listInnitialLength = listLength;
        }
        public T Max()
        {
            T max = _genericList[0];
            foreach (T item in _genericList)
            {
                if (Comparer<T>.Default.Compare(item, max) > 0)
                {
                    max = item;
                }
            }
            return max;
        }
    }
