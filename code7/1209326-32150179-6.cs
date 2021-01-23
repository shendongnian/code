    class ArrayRotator<T> {
    
      public ArrayRotator(T[] array) {
        if (array == null)
          throw new ArgumentException("array");
        var sideLength = (Int32) Math.Sqrt(array.Length);
        if (sideLength*sideLength != array.Length)
          throw new ArgumentException("Not a square.");
        Array = array;
        SideLength = sideLength;
      }
    
      public T[] Array { get; private set; }
    
      public Int32 SideLength { get; private set; }
    
      public void RotateArray() {
        if (SideLength < 3)
          return;
        // Save first element from top edge.
        var element00 = Array[0];
        // Rotate left edge.
        for (var y = 1; y < SideLength; y += 1)
          CopyElement(0, y, 0, y - 1);
        // Rotate bottom edge.
        for (var x = 1; x < SideLength; x += 1)
          CopyElement(x, SideLength - 1, x - 1, SideLength - 1);
        // Rotate right edge.
        for (var y = SideLength - 2; y >= 0; y -= 1)
          CopyElement(SideLength - 1, y, SideLength - 1, y + 1);
        // Rotate top edge.
        for (var x = SideLength - 2; x > 0; x -= 1)
          CopyElement(x, 0, x + 1, 0);
        // Put saved element in place.
        Array[1] = element00;
      }
    
      void CopyElement(Int32 x1, Int32 y1, Int32 x2, Int32 y2) {
        Array[GetIndex(x2, y2)] = Array[GetIndex(x1, y1)];
      }
    
      Int32 GetIndex(Int32 x, Int32 y) {
        return y*SideLength + x;
      }
    
    }
