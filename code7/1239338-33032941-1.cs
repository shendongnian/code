    List<int> numbers = new List<int>();
    decimal sum = 0;
    for (int i = 500; i <= 1500; i++)
    {
        bool divisibleBy3 = i % 3 == 0;
        if (divisibleBy3)
        {
            numbers.Add(i);
            sum += i;
        }
    }
    decimal average = 0m;
    if (numbers.Count > 0)
        average = sum / numbers.Count;
    int[] result = numbers.ToArray();
