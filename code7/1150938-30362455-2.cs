    private void writeFCATSettings()
    {
        XDocument doc = new XDocument(
            new XElement("Items",
                new XElement("textBoxCenterName", textBoxCenterName.Text),
                new XElement("textBoxContactFirstName", textBoxContactFirstName.Text),   
                new XElement("servicedUnits", 
                    listBoxServicedUnits
                    .Items
                    .OfType<Object>()
                    .Select(x => TransformYouObjectToAStringHere)
                    .Select(item => new XElement("unit", item)))));
        doc.Save(@"Settings.xml");
    }
