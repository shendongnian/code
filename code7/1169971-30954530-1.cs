    public class MyList : IEnumerable<int>
    {
        public MyList()
        {
            array = new [] { 1, 2, 3, 4, 5, 6, 7};
        }
        private int[] array;
        int positino = -1;        
        public IEnumerator<int> GetEnumerator()
        {
            for(int i = 0 ; i < array.Length; ++i)
            {
                  yield return array[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
