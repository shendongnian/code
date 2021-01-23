    var numMosqito = 1;
    for (float time = 0; time  <= 8.5; time ++)
    {
         if (time  >= 2)
             numMosqito += numMosqito;
        
    
         Console.WriteLine("{0}, {1}", time, numMosqito);
    }
    
    Console.ReadLine();
