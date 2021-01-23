        using (System.IO.StringReader rxml = new System.IO.StringReader(myxmltext))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MenuConfigBase));
            using (XmlTextReader xr = new XmlTextReader(rxml))
            {
                xr.XmlResolver = null;
                var cfgBase = (MenuConfigBase)serializer.Deserialize(xr);
            }
        }
