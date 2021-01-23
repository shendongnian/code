    class arrys {
      int[] _values;
      public arrys(int size)
      {
           _values = new int[size];
      }
      public int this[int index]
      {
          if (index < _values.Length)
                _values[index];
          else
               return -1;
      }
    }
    // Usage
    arrys a1 = new arrys(21);
    for (int i = 0; i <= 20; i++)
    {
         int a = a1[i];
         Console.WriteLine("a:" + a);
    }
