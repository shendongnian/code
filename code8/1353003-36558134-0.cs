    int first, second;
    //for single digit inputs
    var singleDigitInput1 = Convert.ToChar(Console.Read).ToString();
    var singleDigitInput2 = Convert.ToChar(Console.Read).ToString();
    //for multi digit inputs
    var multiDigitInput1 = Console.ReadLine();
    var multiDigitInput2 = Console.ReadLine()
    if (int.TryParse(singleDigitInput1, out first) && int.TryParse(singleDigitInput2, out second))
    {
        int product = computeProd1(first, second);
        Console.WriteLine("Their product is:\t" + product);
    }
    else
    {
        //input cannot be converted to int
    }
