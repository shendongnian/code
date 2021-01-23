    var result = 0;
    if (sign == "+")
    {
        result = num1 + num2;
    }
    else if (sign == "-")
    {
        result = num1 - num2;
    }
    else if (sign == "*")
    {
        result = num1 * num2;
    }
    else if (sign == "/")
    {
        result = num1 / num2;
    }
    else
    {
        Console.WriteLine("Wrong operation sign ...");
    }
    
    Console.WriteLine("{0}{1}{2}={3}", num1, sign, num2, result);  
    Console.ReadLine();
