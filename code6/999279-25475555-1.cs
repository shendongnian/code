    static ArrayList GetUniqueRandomNumbers(int min, int max, int count)
    {
        Random rng = new Random();
        ArrayList result = new ArrayList();
        while(ArrayList.Count < count)
        {
            int number = rng.Next(min, max);
            // Only add if it hasn't been generated yet
            if (!result.Contains(number))
            {
                result.Add(number);
            }
        }
    }
    static void Main(string[] args)
    {
        ArrayList loto = GetUniqueRandomNumbers(1, 49, 6);
        for (int i = 1; i <= 6; i++)
        {
            // Use the generated numbers
        }
    }
