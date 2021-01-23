    if (character >= '1' && character <= '6')
    {
        var value = (int) char.GetNumericValue(character);
        var index = value - 1;
        Console.WriteLine(names[index]); 
    }
    else
    {
        Console.WriteLine("Incorrect Input");
    }
            
