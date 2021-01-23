    static void Main(string[] args)
    {
        char[] array = " This is  a sentence.".ToCharArray();
        int dst = 0;
        if (array[0] != ' ' && char.IsLetter(array[0]))
        {
            array[dst++] = char.ToUpper(array[0]);
        }
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] == ' ' && char.IsLetter(array[i]))
            {
                array[dst++] = char.ToUpper(array[i]);
            }
        }
        string result = new string(array, 0, dst);
        Console.WriteLine(result);
        Console.ReadLine();
    }
