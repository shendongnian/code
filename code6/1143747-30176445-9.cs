    //using System.Xml;
    public Models Load()
    {
        Models ms = new Models();
        ms.models = new List<Model>();
        XmlDocument xml = new XmlDocument();
        xml.Load(/*path to your file*/);
        foreach (XmlNode model in xml.LastChild.ChildNodes)
        {
            Model m = new Model();
            m.firmwarefiles = new List<FirmwareFile>();
            m.name = model.FirstChild.InnerText;
            foreach (XmlNode firmwarefile in model.LastChild.ChildNodes)
            {
                FirmwareFile f = new FirmwareFile();
                f.filename = firmwarefile.ChildNodes[0].InnerText;
                Version v = new Version();
                Version.TryParse(firmwarefile.ChildNodes[1].InnerText, out v);
                f.version = v;
                f.datecode = Convert.ToInt32(firmwarefile.ChildNodes[2].InnerText);
                m.firmwarefiles.Add(f);
            }
            ms.models.Add(m);
        }
        return ms;
    }
