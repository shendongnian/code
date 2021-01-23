    public class ArrayRow<T> : IList<T>
    {
        private T[,] array;
        private int row;
        public ArrayRow(T[,] array, int row)
        {
            this.array = array;
            this.row = row;
        }
        public T this[int index]
        {
            get
            {
                return array[row, index];
            }
            set
            {
                array[row, index] = value;
            }
        }
        public int Count
        {
            get { return array.GetLength(1); }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int j = 0; j < array.GetLength(1); j++)
                yield return array[row, j];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //TODO implement remaining IList<T> methods
    }
