    for(int i=0; i<limit; i++)
    {
        int value;
        var isNumber = int.TryParse(Console.ReadLine(), out value);
        if(isNumber)
        {
           array1s[i] = value;
        }
        else
        {
           Console.WriteLine("Invalid value you have entered");
           continue;
        }
    }
