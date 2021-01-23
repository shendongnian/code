    XNamespace rs = "urn:schemas-microsoft-com:rowset"; //<---
    XNamespace z = "#RowsetSchema"; //<---
    var doc = XDocument.Parse(DATA);
    IEnumerable<XElement> list = doc.Root.Descendants(rs + "data");
    string returnValue = "";
    foreach (var item in list.Elements(z + "row")) //<---
    {
        returnValue += item.Attribute("POSITION").Value; //<---
        returnValue += "|";
    }
