    Console.Write ("hoeveel appels zijn er :");
    int nummervanappels = Convert.ToInt32(Console.ReadLine());
    while (nummervanappels != 15) 
    { 
        if(nummervanappels > 15)
            Console.WriteLine("dat zijn er te veel");
        else 
            Console.WriteLine("dat zijn er te weinig");
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine ("raad opnieuw");
        System.Threading.Thread.Sleep(2000);
        nummervanappels = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine ("goedzo, er zijn " + nummervanappels + " appels");
    Console.ReadKey ();
