    public static string GetXML(string[] Items)
    {
        if (Items.Length > 0)
        {
            string result = "<" + Items[0] + ">";
            result += GetXML(Items.Skip(1).ToArray());
            result += "</" + Items[0] + ">";
            return result;
        }
        else
        {
            return string.Empty;
        }
    }
