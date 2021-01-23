    for (int i = 0; i < 4; i++)
    {
         int temp = rand.Next(43);
         while (ticket1.Contains(temp))
         {
             temp = rand.Next(43);
         }
         ticket1[i] = temp;
    }
    Console.WriteLine("{0} {1}", item.PadRight(20), string.Join(",", ticket1));
