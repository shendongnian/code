    string input = "red bag";
    string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    string[] test = new string[tokens.Length];
    int size = (int)Math.Pow(tokens.Length, 2);
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < tokens.Length; j++)
        {
            int mask = (1 << j);
            if ((mask & i) != 0)
            {
                test[j] = Pluralize(tokens[j]);
            }
            else
            {
                test[j] = Singularize(tokens[j]);
            }
        }
        Console.WriteLine(string.Join(" ", test));
    }
