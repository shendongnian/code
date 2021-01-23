    private static int[] GetPhoneNumber(int phoneLength = 7)
    {
        List<int> phoneNumbers = new List<int>();
        while (true)
        {
            int numbersLeftToInput = phoneLength - phoneNumbers.Count;
            string placeholder = new String('*', numbersLeftToInput);            
            Console.Clear();
            Console.Write("Phone: {0}{1}", String.Concat(phoneNumbers), placeholder);
            Console.CursorLeft -= numbersLeftToInput;
            var key = Console.ReadKey(intercept: true);
            var c = key.KeyChar;
            if (!Char.IsDigit(c))
                continue;
            phoneNumbers.Add(Int32.Parse(c.ToString()));
            if (phoneNumbers.Count == phoneLength)
                return phoneNumbers.ToArray();
        }
    }
