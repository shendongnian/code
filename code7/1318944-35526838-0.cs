    enum TranType { Buy, Sell, All };
    enum StatType { Volume, Avg, Max, Min, StdDev, Median, Percentile };
    private static string GetStat(XmlDocument xdoc, int id, TranType tranType, StatType statType)
    {
        string xpath = string.Format("/evec_api/marketstat/type[@id = {0}]/{1}/{2}", 
                       id, tranType.ToString().ToLower(), statType.ToString().ToLower());
        return GetFirstElementText(xdoc, xpath);
    }
    private static string GetFirstElementText(XmlDocument xdoc, string xpath)
    {
        // Get the InnerText of the first XmlElement matching the xpath, if any (otherwise null)
        return xdoc.SelectNodes(xpath).Cast<XmlElement>().Select(x => x.InnerText).FirstOrDefault();
    }
