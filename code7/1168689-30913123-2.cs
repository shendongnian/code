    private static double? ReadNumberFromConsole()
    {
        double num;
        if (double.TryParse(Console.ReadLine().Trim(), out num))
            return num;
        else
            return null;
    }
