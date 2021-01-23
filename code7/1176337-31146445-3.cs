    XmlDocument summaryXml = new XmlDocument();
    XmlElement summary = summaryXml.CreateElement("Summary");
    XmlAttribute rev = summaryXml.CreateAttribute("rev");
    rev.Value = newRevNumber;
    summary.Attributes.Append(rev);
    summaryXml.AppendChild(summary);
