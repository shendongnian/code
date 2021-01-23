    private const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";
    public static String GetName(int input)
    {
        var result = new System.Collections.Generic.Stack<char>();
        while (input != 0)
        {
            result.Push(CharList[input % CharList.Length]);
            input /= CharList.Length;
        }
        return "user"+  new string(result.ToArray()).PadLeft(4, '0');
    }
