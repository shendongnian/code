    var dt = new DataTable("Item");
    dt.Columns.Add("ItemNumber");
    dt.Columns.Add("ItemDescription");
    dt.Columns.Add("ItemClass");
    dt.Rows.Add("number1", "desc1", "class1");
    dt.Rows.Add("number2", "desc2", "class2");
    dt.Rows.Add("number3", "desc3", "class3");
    var ds = new DataSet("Batch");
    ds.Tables.Add(dt);
    var settings = new XmlWriterSettings { Indent = true };
    using (var writer = XmlWriter.Create("test.xml", settings))
    {
        writer.WriteStartElement("GreatPlainsIntegration");
        writer.WriteElementString("TransmissionDate", "2015-5-6");
        writer.WriteElementString("TransmissionTime", "20:00");
        //writer.WriteElementString("TargetCatalog", "LWI");
        // and so on
        ds.WriteXml(writer);
    }
