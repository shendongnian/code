    XDocument doc = XDocument.Load(path);
    XName utranCellName = XName.Get("UtranCell", "un");
    XName qRxLevMinName = XName.Get("qRxLevMin", "es");
    var cells = doc.Descendants(utranCellName);
    foreach (var cell in cells)
    {
        string qRxLevMin = cell.Descendants(qRxLevMinName).FirstOrDefault();
        // Do something with the value
    }
