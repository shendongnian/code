    foreach (JProperty item in stuff)
    {
        if (item.Name == "rates")
        {
            exchangeRate.AddRange(from rate in item from xch in rate select xch.ToString());
            foreach (var value in exchangeRate)
            {
                Console.WriteLine(value);
            }
        }
    }
