    bool IsCorrectFormat(string input)
    {
        //14 is a magic number for the length of the expected format
        if (input.Length == 14 && input.StartsWith("T", StringComparison.OrdinalIgnoreCase))
        {
            DateTime dt;
            if (DateTime.TryParseExact(input.Substring(1), "yyyyMMdd.ffff", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                return true;
            }
        }
        return false;
    }
