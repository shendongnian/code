    int sum, temp;
    for (int i = 1; i < 100; i++)
    {
         sum = 0;
         temp = i;
         while (temp != 0)
         {
             sum += temp % 10;
             temp /= 10;
         }
         if (sum % 4 == 0)
         {
             Console.WriteLine(i);
         }
    }
