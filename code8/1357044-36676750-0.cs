    public class MultiDimensionArrayItemReference<T>
    {
        private readonly Array _array;
        private readonly Int32[] _indices;
        public MultiDimensionArrayItemReference(Array array, params Int32[] indices)
        {
            if (array == null)
                throw new ArgumentNullException(paramName: nameof(array));
            if (indices == null)
                throw new ArgumentNullException(paramName: nameof(indices));
            this._array = array;
            this._indices = indices;
        }
        
        public IReadOnlyCollection<Int32> Indices
        {
            get
            {
                return this._indices.ToList().AsReadOnly();
            }
        }
        public T Value
        {
            get
            {
                return (T)this._array.GetValue(this._indices);
            }
            set
            {
                this._array.SetValue(value, this._indices);
            }
        }
        public override string ToString()
        {
            return $"[{String.Join(", ", this._indices)}]:{this.Value}";
        }
    }
    public static class MultiDimensionArrayItemReferenceExtensions
    {
        // That's for the two-dimensional array, but with some effort it can be generalized to support any arrays.
        public static IEnumerable<MultiDimensionArrayItemReference<T>> EnumerateReferenceElements<T>(this T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(paramName: nameof(array));
            // Assume zero-based
            var rows = array.GetLength(0);
            var columns = array.GetLength(1);
            for (int row = 0; row < rows; row++)
            { 
                for (int col = 0; col < columns; col++)
                {
                    yield return new MultiDimensionArrayItemReference<T>(
                        array,
                        row,
                        col);
                }
            }
        }
    }
...
    private static void PrintArray<T>(T[,] array)
    {
        // Assume zero-based
        var rows = array.GetLength(0);
        var columns = array.GetLength(1);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write("{0, 7}", array[row, col]);
            }
            Console.WriteLine();
        }
    }
