    public static bool ReadIntegerConsole2(out int number)
    {
        int input;
        bool ok = true;
        number = 0;
        if (int.TryParse(Console.ReadLine(), out input))
            number = input;
        else
        {
            ok = false;
            Console.WriteLine("Wrong input. Please try again: ");
        }
        return ok;
    }
