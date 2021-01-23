    var xmlValues = System.Web.HttpUtility.HtmlDecode(nodeElements.InnerText);
    //you might want to use System.Net.WebUtility.HtmlDecode instead to avoid System.Web
    XmlDocument valuesDoc = new XmlDocument();
    valuesDoc .LoadXml(xmlValues );
    var vals = valuesDoc.SelectNodes("//Value");
    //Here You Can iterate on vals
