    BigInteger val = 0;
    long v;
    long pow = name.Length-1;
    foreach (char c in name) {
        if (char.IsNumber(c))
            v = (long)c;
        else
        {
            v = char.ToUpper(c) - 54; 
            val += v * (long)Math.Pow((double)36, (double)pow);
        }
        Console.WriteLine(v+","+pow+","+val);
        pow--;
        val = val % 100000;
    }
