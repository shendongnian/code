    string input = Console.ReadLine();
    for (i = 0; i < input.Length; i++ )
    {
        int k = Convert.ToInt32(input.Substring(i, 1));
        if (k==1)
        {
            ans++;
        }
    }
