    var summaryXml = new XmlDocument();
    var summaryElement = summaryXml.CreateElement("Summary");
    var revAttribute = summaryXml.CreateAttribute("rev");
    revAttribute.Value = newRevNumber;
    summaryElement.Attributes.Append(revAttribute);
    summaryXml.AppendChild(summaryElement);
