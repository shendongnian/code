    static void Main(String[] args)
    {
        foreach (var column in GetColumns().Take(52))
        {
            Console.WriteLine(column);
        }
        Console.ReadLine();
    }
    public static IEnumerable<string> GetColumns()
    {
        const string Alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int index = 1; ; index++)
        {
            if (index % Alphabet.Length == 0)
            {
                continue;
            }
            var columnName = string.Empty;
            int value = index;
            do
            {
                columnName = Alphabet[value % Alphabet.Length] + columnName;
                value = value / Alphabet.Length;
            } while (value > 0);
            yield return columnName;
        }
    }
