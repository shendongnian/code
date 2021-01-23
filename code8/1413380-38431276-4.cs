    public static bool SelfDescribing(string num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            var count = num.Count(x => x == char.Parse(i.ToString()));
            if (count != char.GetNumericValue(num[i]))
                return false;
        }
        return true;
    }
