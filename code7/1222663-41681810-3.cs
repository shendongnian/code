    public class Matrix<T>
    {
        readonly int rows, cols;
        readonly T[][] elements;
        public Matrix(int rows, int cols)
        {
            this.rows=rows;
            this.cols=cols;
            this.elements=new T[rows][];
            for(int i = 0; i<rows; i++)
            {
                elements[i]=new T[cols];
            }
        }
        public int Rows { get { return rows; } }
        public int Columns { get { return cols; } }
        public T this[int row, int col]
        {
            get { return elements[row][col]; }
            set { elements[row][col]=value; }
        }
        public T[] GetRow(int row) { return elements[row]; } // This is fast
        public T[] GetColumn(int col) // This is slow
        {
            T[] column = new T[rows];
            for(int i = 0; i<rows; i++)
            {
                column[i]=elements[i][col];
            }
            return column;
        }
        public T[][] GetSubMatrix(int row, int col, int row_count, int col_count)
        {
            T[][] result = new T[row_count][];
            for(int i = 0; i<row_count; i++)
            {
                // This is fast
                Array.Copy(elements[row+i], col, result[i], 0, col_count);
            }
            return result;
        }
        public void SetSubMatrix(int row, int col, T[][] matrix)
        {
            int row_count = matrix.Length;
            int col_count = row_count>0 ? matrix[0].Length : 0;
            for(int i = 0; i<row_count; i++)
            {
                // This is fast
                Array.Copy(matrix[i], 0, elements[row+i], col, col_count);
            }
        }
    }
