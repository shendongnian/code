    int superlistCounter = 1;
    int sublistCounter = 1;
    foreach(var sublist in list)
    {
       Console.WriteLine("Now in List #" + superlistCounter);
       foreach(var item in sublist)
       {
           Console.WriteLine("List item #" + sublistCounter + ": " + item)
       }
    }
