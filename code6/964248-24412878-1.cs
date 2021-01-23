    for (int i = 0; i < s.Length; i++)
    {
        if(s[i] == b)
        {
            h[i] = b;
        }
        else
        {
            h[i] = '-';
        }
        Console.Write(h[i]);
    }
