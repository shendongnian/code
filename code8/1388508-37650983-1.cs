    static void Main(string[] args)
    {
        char[] array = "test test test".ToCharArray();
        int dst = 0;
        // NOTE: I guess you want to make an exception for array[0] judging from your comments
        if (array[0] != ' ')
        {
            array[dst++] = char.ToUpper(array[0]);
        }
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] == ' ')
            {
                array[dst++] = char.ToUpper(array[i]);
            }
        }
        string result = new string(array, 0, dst);
        Console.WriteLine(result);
        Console.ReadLine();
    }
