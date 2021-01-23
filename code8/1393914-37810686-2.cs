    public static string GetXML(IEnumerable<string> Items)
    {
        if (Items.Any())
        {
            return string.Format("<{0}>{1}</{0}>", Items.First(), GetXML(Items.Skip(1)));
        }
        else
        {
            return string.Empty;
        }
    }
