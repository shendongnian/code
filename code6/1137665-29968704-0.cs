    public class ArrayRow<T> : IEnumerable<T>
    {
        private T[,] array;
        private int index;
        public ArrayRow(T[,] array, int index)
        {
            this.array = array;
            this.index = index;
        }
        public T this[int i]
        {
            get { return array[index, i]; }
            set { array[index, i] = value; }
        }
        public int Count { get { return array.GetLength(1); } }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public static ArrayRow<T> GetRow<T>(this T[,] array, int index)
    {
        return new ArrayRow<T>(array, index);
    }
