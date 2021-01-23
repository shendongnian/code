    if (IsdenominatorConverstionSucess)
    {
        if(denominator==0)
        {
            Console.WriteLine("NOtZero");
        }
        else
        {
            int result = numerator / denominator;
            Console.WriteLine("Result is = {0}", result);
        }
   
    }
    else
    {
        Console.WriteLine("Denominator Should Be A Valid Number Between {0} To {1} Range", Int32.MinValue, Int32.MaxValue);
    }
