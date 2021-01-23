    public static bool TryReadIntegerConsole2(out int input)
    {
        if (int.TryParse(Console.ReadLine(), out input))
            return true;
        Console.WriteLine("Wrong input. Please try again: ");
        return false;
    }
