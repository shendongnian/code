    public int FlagCount(this System.Enum sender)
    {
      return sender.GetFlaggedValues().Count;
    }
    
    /// <summary>
    /// All of the values of enumeration that are represented by specified value.
    /// If it is not a flag, the value will be the only value returned
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static List<Enum> GetFlaggedValues(this Enum value)
    {
        //checking if this string is a flagged Enum
        Type enumType = value.GetType();
        object[] attributes = enumType.GetCustomAttributes(true);
        
        bool hasFlags = enumType.GetCustomAttributes(true).Any(attr => attr is System.FlagsAttribute);
        //If it is a flag, add all flagged values
        List<Enum> values = new List<Enum>();
        if (hasFlags)
        {
            Array allValues = Enum.GetValues(enumType);
            foreach (Enum currValue in allValues)
            {
                if (value.HasFlag(currValue))
                {
                    values.Add(currValue);
                }
            }
        }
        else//if not just add current value
        {
            values.Add(value);
        }
        return values;
    }
