    public static void PrepareTest()
    {
      data = new Base[Program.ObjCount]; // 10000
      for (int i = 0; i < data.Length; i++)
        data[i] = new Data(); // Data consists of four floats
    }
