    for (x = 0; x < prices.Length; x++)
    {
      count += 1;
      Console.Write("Enter the price for {0}: ", count);
      inputString = Console.ReadLine();
      prices[x] = Convert.ToDouble(inputString);
      TotalValues += prices[x];
      if (prices[x] < 5) {
        lessthanfive++;
      }
    }
    Average = TotalValues / prices.Length;
    for (x = 0; x < prices.Length; x++)
    {
       if (prices[x] > Average) {
         higherthanaverage++;
       }
    }
