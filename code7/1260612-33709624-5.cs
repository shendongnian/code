    public static void PrintMatrix(List<int> tictactoe)
    {
        for (int i = 0; i < 3; i = i + 3)
            Console.WriteLine($"[{tictactoe[i]},{tictactoe[i + 1]},{tictactoe[i + 2]}]");
    }
