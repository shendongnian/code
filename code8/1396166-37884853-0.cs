    void Main()
    {
        var rng = new Random();
        var validValues = Enumerable.Range(1, 20).Except(new int[] {6, 7, 8}).ToArray();
        
        for (int i = 0; i < 25; i++)
        {
            Console.Write(validValues[rng.Next(0, validValues.Length)]);
            Console.Write(" ");
        }
    }
