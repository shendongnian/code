    public static string GetTimeAsHex(System.DateTime dt)
    {
        System.DateTime zero = new System.DateTime(1900, 1, 1);
        System.TimeSpan ts = dt - zero;
        System.TimeSpan ms = ts.Subtract(new System.TimeSpan(ts.Days, 0, 0, 0));
        double x = System.Math.Floor(ms.TotalMilliseconds / 3.3333333333);
        string hex = "0x" + ts.Days.ToString("X8") + System.Convert.ToInt32(x).ToString("X8");
        return hex;
    }
