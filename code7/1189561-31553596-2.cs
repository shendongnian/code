    List<decimal> decimals = new List<decimal>
    {
        500000M,
        500000.9M,
        500000.99M,
        500000.999M,
        500000.9999M,
        500000.9000M 
    };
    foreach (decimal d in decimals)
    {
        string dStr = d.ToString();
        if (!dStr.Contains("."))
        {
            Console.WriteLine(d + ",");
        }
        else
        {
            // Trim any trailing zeroes after the decimal point
            dStr = dStr.TrimEnd('0');
            string[] pieces = dStr.Split('.');
            if (pieces[1].Length < 2)
            {
                // Ensure 2 significant digits
                pieces[1] = pieces[1].PadRight(2, '0');
            }
            Console.WriteLine(String.Join(",", pieces));
        }
    }
