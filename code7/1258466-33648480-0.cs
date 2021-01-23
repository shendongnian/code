    public static string ToDecimalValuesString(this float[] items, string separator = ", ")
    {
        var result = new StringBuilder();
        for (int i = 0; i < items.Length; i++)
        {
            result.Append(items[i].ToString("R", NumberFormatInfo.InvariantInfo));
            if (i < items.Length - 1)
                result.Append(separator);
        }
        return result.ToString();
    }
