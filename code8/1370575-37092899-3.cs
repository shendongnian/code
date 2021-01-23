    // int?[] numbers = new int?[] { 8, 1, 4, 3, 3, 6, 3, 2, 3 };
    int?[] numbers = new int?[] { -7, -7, -7, -100, -100, -99, 4, -90, -80, -70 };
    Console.WriteLine("Array: [{0}]", String.Join(", ", numbers));
    System.Diagnostics.Stopwatch watch = new Stopwatch();
    watch.Start();
    int minValue = Int32.MinValue;
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        var currentNumber = numbers[i];
        var nextNumber = numbers[i + 1];
        if (currentNumber > nextNumber)
        {
            if (nextNumber < minValue)
            {
                numbers[i + 1] = null;
            }
            else
            {
                minValue = nextNumber.Value;
                for (int j = i; j >= 0; j--)
                {
                    if (numbers[j] > minValue)
                    {
                        numbers[j] = null;
                    }
                }
            }
        }
    }
    watch.Stop();
    Console.WriteLine("Result: {0}; Time: {1} ms", numbers.Count(number => number == null), watch.ElapsedMilliseconds);
    Console.WriteLine("Array: [{0}]", String.Join(", ", numbers));
