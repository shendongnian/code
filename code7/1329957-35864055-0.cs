    for (int i = 0; i < str.Length; i++)
    {
        int count = 0;
        Char[] strArray = str[i].ToCharArray();
        for (int j = 0; i < strArray.Length; j++)
        {
            if (strArray[i] == strArray[i + 1])
            {
                count++;
            }
        }
        Console.WriteLine(count);
        Console.ReadLine();
    }
