    public static bool IsColor(string col)
    {
        System.Drawing.KnownColor nc;
        Enum.TryParse(col, true, out nc);
        var returnColor = System.Drawing.Color.FromKnownColor(nc);
        return returnColor.Name != "0";
    }
