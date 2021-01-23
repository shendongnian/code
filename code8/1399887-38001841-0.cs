    var xmlValues = System.Web.HttpUtility.HtmlDecode(nodeElements.InnerText);
    XmlDocument valuesDoc = new XmlDocument();
    valuesDoc .LoadXml(xmlValues );
    var vals = valuesDoc.SelectNodes("//Value");
    //Here You Can iterate on vals
