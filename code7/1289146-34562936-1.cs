    public sealed class Array2D<T>
    {
         private T[,] _fields;
         //Or as property
         public T[,] Fields
         {
             get { return _fields; }
             set { _fields = value; }
         }
         public Array2D()
         {
                
         }
    }
