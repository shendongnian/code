    var list = new List<string>(19000);
    
    List<Task> tl = new List<Task>(19000);
    
    for (int q = 0; q < 19000; q++)
    {
        tl.Add(Task.Factory.StartNew(() =>
        {
           lock(_sync)
           {
              var k = "something";
              list.Add(k);
           }
        }));
    }
    
    Task.WaitAll(tl.ToArray());
    Console.WriteLine(list.Count);
