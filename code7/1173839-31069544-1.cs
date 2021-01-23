    public static readonly string[] Order = new string[4] {"swim","baseball","volleyball","soccer"};
    public static int OrderOf(string str)
    {
        int ix = Array.IndexOf(Order, str);
        if (ix == -1)
        {
            ix = int.MaxValue;
        }
        return ix;
    }
