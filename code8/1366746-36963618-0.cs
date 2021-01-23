    public int FlagCount(System.Enum sender)
    {
        bool hasFlagAttribute = sender.GetType().GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0;
        if (!hasFlagAttribute) // No flag attribute. This is a single value.
            return 1;
    
        var resultString = Convert.ToString(Convert.ToInt32(sender), 2);
        var count = resultString.Count(b=> b == '1');//each "1" represents an enum flag.
        return count;
    }
