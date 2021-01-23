    private static DateTime? ExtractPostedDate(string inputHtml, string controlID = "postedDate")
    {
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(inputHtml);
        HtmlNode  div = doc.GetElementbyId(controlID);
        DateTime? result = null;
        DateTime value;
        if (div != null && DateTime.TryParse(div.InnerText.Trim(), DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out value))
            result = value;
        return result;
    }
