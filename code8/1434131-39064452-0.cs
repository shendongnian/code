    public static string TextfromOneNode(HtmlNode node, string xmlPath)
    {
        string toReturn = "";
        var navigator = (HtmlAgilityPack.HtmlNodeNavigator)node.CreateNavigator();
        var result = node.SelectSingleNode(xmlPath);
        if(result != null)
        {
            toReturn = result.Value;
        }
        return toReturn;
    }
