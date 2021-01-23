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
    
        public void Place(Matrix<T> src, int destR, int destC)
        {
            for (int row = 0; row < src.Rows; row++)
            {
                for (int col = 0; col < src.Cols; col++)
                {
                    this[row + destR, col + destC] = src[row, col];
                }
            }
        }
    
        public override string ToString()
        {
            string result = "";
    
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    result += this[row, col].ToString() + '\t';
                }
                result += '\n';
            }
    
            return result;
        }
    }
