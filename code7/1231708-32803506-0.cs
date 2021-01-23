    Console.Write("\nEnter a Whole Number (Such as 12)\n");
    string Input = Console.ReadLine();
    
    char firstChar = Input[0];
    bool isNumber = Char.IsDigit(firstChar);
    
    if (!isNumber)
    {
         Console.WriteLine("Not an integer");
    } 
    else 
     {
    .......
    }
