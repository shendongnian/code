    for(var i = 0; i < 100; i+=1)
    {
        if(i == 50)
        {
            goto Outer;
        }
    }
    
    Outer:
    Console.WriteLine("Done");
