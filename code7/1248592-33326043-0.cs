    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Resize<T>(ref T[] array, int newSize)
    {
      if (newSize < 0)
        throw new ArgumentOutOfRangeException("newSize", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      T[] objArray1 = array;
      if (objArray1 == null)
      {
        array = new T[newSize];
      }
      else
      {
        if (objArray1.Length == newSize)
          return;
        T[] objArray2 = new T[newSize];
        Array.Copy((Array) objArray1, 0, (Array) objArray2, 0, objArray1.Length > newSize ? newSize : objArray1.Length);
        array = objArray2;
      }
    }
