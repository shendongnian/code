    using System.Text.RegularExpressions;
    using System.Web;
    using System.Xml;
    XmlDocument doc = new XmlDocument();
                
    doc.LoadXml(spResXml.OuterXml);
    System.Xml.XmlNamespaceManager nm = new System.Xml.XmlNamespaceManager(doc.NameTable);
    nm.AddNamespace("rs", "urn:schemas-microsoft-com:rowset");
    nm.AddNamespace("z", "#RowsetSchema");
    nm.AddNamespace("rootNS", "http://schemas.microsoft.com/sharepoint/soap");
 
    var zRows = doc.SelectNodes("//z:row", nm);
    for (int i = 0; i < zRows.Count; i++)
    {
        XmlNode zRow = zRows[i];
        List<XmlAttribute> attsList = new List<XmlAttribute>();
        for (int j = 0; j < zRow.Attributes.Count; j++)
        { attsList.Add(zRow.Attributes[j]); }
     
        foreach (XmlAttribute att in attsList)
        {
           string patchedAttName = att.Name;
           patchedAttName = patchedAttName.Replace("_x", "%u");
           patchedAttName = HttpUtility.UrlDecode(patchedAttName);
           patchedAttName = Regex.Replace(patchedAttName,"[^A-Za-z0-9_]", "_", RegexOptions.None);
           if (att.Name.Equals(patchedAttName))
           { continue; }
           var newAtt = doc.CreateAttribute(att.Prefix, patchedAttName, att.NamespaceURI);
           newAtt.Value = att.Value;
           zRow.Attributes.Remove(att);
           zRow.Attributes.Append(newAtt);
        }
     }
     DataSet ds = new DataSet();
     ds.ReadXml(new XmlNodeReader(doc));
     t = ds.Tables[1];
