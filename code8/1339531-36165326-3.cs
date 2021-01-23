    public static string PadInt(int value)
    {
        var output = value.ToString();
        while (output.Length < 4)
        {
            output = "0" + output;
        }
        return output;
    }
