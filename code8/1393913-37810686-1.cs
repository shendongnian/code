    public static string GetXML(IEnumerable<string> Items)
    {
        if (Items.Count() > 0)
        {
            return string.Format("<{0}>{1}</{0}>", Items.First(), GetXML(Items.Skip(1)));
        }
        else
        {
            return string.Empty;
        }
    }
