    private const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";
    public static String GetName(int input)
    {
        string result = string.Empty;
        while (input != 0)
        {
            result = CharList[input % CharList.Length] + result;
            input /= CharList.Length;
        }
        return "user" + result.PadLeft(4, '0');
    }
