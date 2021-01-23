    Random r = new Random();
    int min = int.MaxValue,
        max = int.MinValue;
    long sum = 0;
    const int count = 1000;
    for (int i = 0; i < count; i++)
    {
        int n = r.Next();
        sum += n;
        
        if (n < min)
            min = n;
        if (n > max)
            max = n;
    }
    double avg = (double)sum / count;
    Console.WriteLine("Min = {0}, Max = {1}, Sum = {2}, Avg = {3}", min, max, sum, avg);
