    abstract public class Matrix2dv1
    {
        double[,] data;
        protected Matrix2dv1(double[,] source)
        {
            data = (double[,])source.Clone();
        }
        public double this[int row,int column]
        {
            get { return data[row, column]; }
        }
    }
    abstract public class Matrix2dv2
    {
        abstract public double this[int row, int column] { get; }
    }
    abstract public class Matrix2dv3
    {
        public double this[int row, int column]
        {
            get { return getRowColumn(row,column); }
        }
        protected abstract double getRowColumn(int row, int column); 
    }
