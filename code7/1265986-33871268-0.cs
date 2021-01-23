    public class DualAccessArray<T>
    {
      private readonly T[,] _internalArray;
      private readonly int _width;
      private readonly int _height;
    
      public DualAccessArray(int width, int height)
      {
        _width = width;
        _height = height;
        _internalArray = new T[width, height];
      }
      
      public T this[long index]
      {
        get { return _internalArray[index / _width, index % _width]; }
        set { _internalArray[index / _width, index % _width] = value; }
      }
      
      public T this[int x, int y]
      {
        get { return _internalArray[x, y]; }
        set { _internalArray[x, y] = value; }
      }
    }
