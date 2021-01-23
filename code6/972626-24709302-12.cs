    class Matrix<T>
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }
    
        private T[,] mat;
    
        public Matrix(int rowCount, int colCount)
        {
            Rows = rowCount;
            Cols = colCount;
            mat = new T[Rows, Cols];
        }
    
        public T this[int r, int c]
        {
            get { return mat[r, c]; }
            set { mat[r, c] = value; }
        }
    }
