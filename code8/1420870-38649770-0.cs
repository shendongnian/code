    public void CollectHeader()
    {
        string inputValue;
        Console.WriteLine("What name of the company {0}?", companyName);
        inputValue = Console.ReadLine();
        companyName = inputValue;
        Console.WriteLine("What is the address?", companyAddress);
        inputValue = Console.ReadLine();
        companyAddress = inputValue;
        Console.WriteLine("What is the sales tax?", salesTax);
        inputValue = Console.ReadLine();
        float salesTax = float.Parse(inputValue);
        
        //Assuming that salesTax is in the form of 1 + decimal percentage. For example, for a 5% tax, salesTax would be 1.05.
        float totalPrice = productPrice1*salesTax + productPrice2*salesTax + productPrice3*salesTax;
        
        Console.WriteLine("The total cost is " + totalPrice.ToString("c2") + ". Thank you for shopping at StackOverFlowmart.");
    }
