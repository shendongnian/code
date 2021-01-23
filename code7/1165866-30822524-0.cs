    public byte ConvertToByte(bool[] arr)
    {
       byte val = 0;
       foreach (bool b in arr)
       {
          val <<= 1;
          if (b) val |= 1;
       }
       return val;
    }
