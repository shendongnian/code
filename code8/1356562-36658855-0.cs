    static void Main(string[] args)
    {
        string input = "00B50578 00A41434 00B50578";
        string foo = "6F6F6F6F6F";
    
        Queue <char> fooQueue = new Queue<char>(foo);
    
        StringBuilder result = new StringBuilder();
        foreach (var item in input.Split(' '))
        {
            for (int i = 0; i < item.Length - 1; i += 2)
            {
                var substring = item.Substring(i, 2);
                if (substring == "00")
                {
                    result.Append("00");
                }
                else
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (fooQueue.Count >= 1)
                            result.Append(fooQueue.Dequeue());
                        else
                            result.Append(substring[j]);
                    }
                }
            }
            result.Append(' ');
        }
        Console.WriteLine(result.ToString().Trim());
    }
