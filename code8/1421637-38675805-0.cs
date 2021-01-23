    for (int i = 0; i <=100; i++)  {
       if(i%7 == 0) Console.WriteLine (i); 
       if(i%10 == 0 && i!=0)  Console.WriteLine (i); 
    } 
        Enumerable.Range(7,100)   
    .Where(i => i%10 == 0).ToList().AddRange(
    Enumerable.Range(0,100)   
    .Where(i => i%7 == 0).ToList())
        .ForEach(i=> {Console.WriteLine (i); });
