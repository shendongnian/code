    public class MyList : IEnumerable<int>
    {
        public MyList()
        {
            array = new[] { 1, 2, 3, 4, 5, 6, 7 };
        }
        private int[] array;
        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)array).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
