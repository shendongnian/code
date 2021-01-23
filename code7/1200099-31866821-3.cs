    public int Min(int[] numbers)
    {
        int m = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (m > numbers[i])
            {
                m = numbers[i];
            }
        }
        return m;
    }
    public int Max(int[] numbers)
    {
        int m = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (m < numbers[i])
            {
                m = numbers[i];
            }
        }
        return m;
    }
