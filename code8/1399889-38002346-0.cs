    if (cvorElementi.Name == "SpecificationItemValues")
    {
    var xmlValues = System.Net.WebUtility.HtmlDecode(cvorElementi.InnerText);
        XmlDocument valuesDoc = new XmlDocument();
        valuesDoc.LoadXml(xmlValues);
        foreach (XmlNode valuesNode in valuesDoc.SelectSingleNode("//Values"))
        {
            if (valuesNode.Name=="Value")
                {
                 MessageBox.Show(valuesNode.InnerText);
                }
        }
    }                               
