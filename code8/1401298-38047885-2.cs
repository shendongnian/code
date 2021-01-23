    private const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";
    public static String GetName(int input)
    {
        StringBuilder result = new StringBuilder();
        while (input != 0)
        {
            result.Insert(0,CharList[input % CharList.Length]);
            input /= CharList.Length;
        }
        return "user" + result.ToString().PadLeft(4, '0');
    }
