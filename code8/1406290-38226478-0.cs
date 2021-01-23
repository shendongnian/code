     //updating config file
    XmlDocument XmlDoc = new XmlDocument();
    //Loading the Config file
    XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
    foreach (XmlElement xElement in XmlDoc.DocumentElement)
    {
        if (xElement.Name == "connectionStrings")
        {
            //setting the coonection string
            xElement.FirstChild.Attributes[2].Value = con;
        }
    }
    //writing the connection string in config file
    XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
