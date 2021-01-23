    for (int i = 1; i <= 50000; ++i)
    {
        oxa = new List<OpenXmlAttribute>();
        // this is the row index
        oxa.Add(new OpenXmlAttribute("r", null, i.ToString()));
        oxw.WriteStartElement(new Row(), oxa);
        for (int j = 1; j <= 100; ++j)
        {
            oxa = new List<OpenXmlAttribute>();
            // this is the data type ("t"), with CellValues.String ("str")
            oxa.Add(new OpenXmlAttribute("t", null, "str"));
            // it's suggested you also have the cell reference, but
            // you'll have to calculate the correct cell reference yourself.
            // Here's an example:
            //oxa.Add(new OpenXmlAttribute("r", null, "A1"));
            oxw.WriteStartElement(new Cell(), oxa);
            oxw.WriteElement(new CellValue(string.Format("R{0}C{1}", i, j)));
            // this is for Cell
            oxw.WriteEndElement();
        }
        // this is for Row
        oxw.WriteEndElement();
    }
