    int[] tal = new int[1000];
    for (int i = 0; i < tal.Length; i++)
    {
        tal[i] += i + 500; // 500 based number
    }
    int summa = 0;
    int k = 0;
    for (int i = 0; i < tal.Length; i++)
    {
        if (tal[i] % 3 == 0)
        {
            summa += tal[i];
            k++; // count number of summed.
        }
    }
    double average = 0;
    if(k != 0) // prevent division by zero
    {
        average = (double)summa/k; // cast to double to hold precision.
    }
    Console.WriteLine(average);
