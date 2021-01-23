        double inft, convert, value = 0.3048;
        int ft, inchesleft;
        string input;
        Console.WriteLine("please enter amount of metres");
        input = Console.ReadLine();
        convert = double.Parse(input);
        inft = convert / value;
        ft = (int)inft;
        double temp = (inft - Math.Truncate(inft)) / 0.08333; 
        inchesleft = (int)temp; // to be more accurate use temp variable which contains the decimal point value of inches 
        Console.WriteLine("{0} feet {1} inches.", ft, inchesleft);
        Console.ReadLine();
