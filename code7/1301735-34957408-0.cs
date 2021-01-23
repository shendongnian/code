    public class TestClass : IEnumerable<int>
    {
        private static readonly int[] Empty = new int[0];
        public int[] List;
    
        public IEnumerator<int> GetEnumerator() 
        {
            int[] array = List == null ? Empty : List;
            return array.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerator.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
