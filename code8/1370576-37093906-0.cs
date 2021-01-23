    using System;
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            numbers.Add(currentNumber);
        }
        int[] size = new int[numbers.Count];
        // Define each number as subsequence.
        for (int i = 0; i < numbers.Count; i++)
        {
            size[i] = 1;
        }
        int max = 1;
        // Compare current number with the numbers before.
        for (int i = 1; i < numbers.Count; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (numbers[i] >= numbers[j] && size[i] <= size[j] + 1)
                {
                    size[i] = size[j] + 1;
                    // Update max increasing subsequence.
                    if (max < size[i])
                    {
                        max = size[i];
                    }
                }
            }
        }
        // Print numbers to remove as a result.
        int numbersToRemove = n - max;
        Console.WriteLine(numbersToRemove);
    }
