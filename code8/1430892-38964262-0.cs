    static class extensions
    {
        public static T[][] toJagged<T>(this T[,] source)
        {
            int rows = source.GetLength(0);
            int columns = source.GetLength(1);
            int size = System.Runtime.InteropServices.Marshal.SizeOf<T>();
            var result = new T[rows][];
            for (int r = 0; r < rows; r++)
            {
                var temp = new T[columns];
                Buffer.BlockCopy(source, r * columns * size, temp, 0, columns * size);
                result[r] = temp;
            }
            return result;
        }
        public static T[,] to2D<T>(this T[][] source)
        {
            int rows = source.Length;
            int columns = source.Select(i => i == null ? 0 : i.Length).Max(); // the longest row
            var result = new T[rows, columns];
            int size = System.Runtime.InteropServices.Marshal.SizeOf<T>();
            int offset = 0;
            foreach(var row in source)
            {
                if (row != null)
                    Buffer.BlockCopy(row, 0, result, offset * size, row.Length * size);
                offset += columns;
            }
            return result;
        }
    } // end of class extensions
