    public static void SaveCellPhoneProducts(List<ProducCellPhone> LocalProducts)
    {
        //xml writer settings
        XmlWriterSettings localSettings = new XmlWriterSettings();
        localSettings.Indent = true;
        localSettings.IndentChars = ("   ");
        using (var xmlOut = XmlWriter.Create(path, localSettings))
        {
            xmlOut.WriteStartDocument();
            //write each product on xml file
            foreach(ProducCellPhone localProduct in LocalProducts)
                WriteCellPhoneProductBase(localProduct, xmlOut);
            xmlOut.WriteEndDocument()
        }
    }
