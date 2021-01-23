    foreach (var figure in figures)
    {
        int intOut;
        decimal decimalOut;
        
        // Note that you would have to check for integers first, because 
        // integers would otherwise be detected as valid decimals in advance.
        if (int.TryParse(figure, out intOut))
        {
            Console.WriteLine("{0}: Integer Number", figure);
        }
        else if (decimal.TryParse(figure, out decimalOut))
        {
            Console.WriteLine("{0}: Floatingpoint Number", figure);
        }
        else
        {
            Console.WriteLine("{0}: No Number", figure);
        }
    }
