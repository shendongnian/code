    int batchId = 1;   
    while(Console.ReadLine()!= "stop")//Replace this getting latest batch id, until then use this for getting code
    {
      for (int i = 1; i <= 100; i ++ )
      {
      Console.WriteLine("{0}/{1}", batchId, i.ToString("00"));
      }
      batchId++;
    }
