    float[] data = new float[150000];
    Random rnd = new Random(12345);
    
    for (int i = 0; i < data.Length; i++)
    {
        data[i] = (float)(rnd.NextDouble() * 5000.0 - 2500.0);
    }
    
    Stopwatch sw = new Stopwatch();
    
    sw.Start();
    
    var varsum = 0.0;  //varsum is a DOUBLE!!!!
    
    for (int i = 0; i < data.Length; i++)
        varsum += Math.Max(data[i], 0);        //implicit conversions, float->double, int->float
    
    sw.Stop();
    
    Console.WriteLine("Varsum : " + varsum);
    
    Console.WriteLine("Time it took for the original: " + sw.Elapsed.TotalMilliseconds + " ms");
       
    float floatsum = 0.0f;
        
    sw.Reset();
    sw.Start();
    
    floatsum = 0.0f;
    
    for (int i = 0; i < data.Length; i++)
        if (data[i] > 0.0f)
            floatsum += data[i];
    
    sw.Stop();
    
    Console.WriteLine("OptimizedSum: " + floatsum);
    
    Console.WriteLine("Time it took for \"optimized\" version: " + sw.Elapsed.TotalMilliseconds + " ms");
    
    Console.ReadKey(true);
