    for (int i = 0; i < str.Length; i++)
    {
        int count = 0;
        Char[] strArray = str[i].ToCharArray();
        for (int j = 0; j < strArray.Length; j++)
        {
            if (strArray[j] == strArray[j + 1])
            {
                count++;
            }
        }
        Console.WriteLine(count);
        Console.ReadLine();
    }
