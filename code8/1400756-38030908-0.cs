    class MatrixN {
       private double[,] inner;
       public double this[int x, int y] {
           get { return inner[x, y]; }
           set { inner[x, y] = value; }
       }
    }
