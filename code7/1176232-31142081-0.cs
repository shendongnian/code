    try
    {
        double[,] matrix = new double[2, 2];
        String liczba = "85481";
        matrix[1, 1] = double.Parse(liczba);
    }        
    catch (OverflowException)
    {
        Console.WriteLine("exceeded scope of variable");
    }
    catch (FormatException)
    {
        Console.WriteLine("variable converstion error");
    }
    catch (Exception)
    {
        Console.WriteLine("general exception");
    }
