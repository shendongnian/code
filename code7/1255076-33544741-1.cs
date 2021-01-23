    var sw = Stopwatch.StartNew();
    for(int i = 0; i < 1000000000; i++)
    {
      List<int> a = new List<int>();
      a.Add(i);
      a.Add(i+2);
      int b = a.First();//[0] for B
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedTicks); 
