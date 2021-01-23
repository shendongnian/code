    private static int[] GetPhoneNumber(int phoneLength = 7)
    {
        List<int> phoneNumbers = new List<int>();
        while (true)
        {
            EditorFor("Phone", String.Concat(phoneNumbers), phoneLength);
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Escape) 
                return new int[0]; // return empty array if user cancelled input
            var c = key.KeyChar;
            if (!Char.IsDigit(c))
                continue;
            phoneNumbers.Add(Int32.Parse(c.ToString()));
            if (phoneNumbers.Count == phoneLength)
            {
                EditorFor("Phone", String.Concat(phoneNumbers), phoneLength);
                return phoneNumbers.ToArray();
            }
        }
    }
