    public static void someOtherMethod(){
        XmlDocument doc = new XmlDocument();
        doc.Load(GlobalSettings.appDefaultFolder + "backups.xml");
        // some loop..
          doc.DocumentElement.AppendChild(createNode(id[i], foldername[i], backupdate[i]));
        doc.Save(GlobalSettings.appDefaultFolder + "backups.xml");
    }
    public static void createNode(string id, string foldername, string backupdate)
    {
        XmlElement backupNodeNew = doc.CreateElement("backup");
        XmlAttribute backupId = doc.CreateAttribute("id");
        backupId.Value = id;
        backupNodeNew.Attributes.Append(backupId);
        XmlNode nodeTitle = doc.CreateElement("foldername");
        nodeTitle.InnerText = foldername;
        XmlNode nodeUrl = doc.CreateElement("backupdate");
        nodeUrl.InnerText = backupdate;
        backupNodeNew.AppendChild(nodeTitle);
        backupNodeNew.AppendChild(nodeUrl);
        return backupNodeNew;
    }
