    public ReadXml(string xmlPath)
        {
                try
                {
                    XDocument xDoc = XDocument.Load(configFilePath);
                    
                    XElement root = xDoc.Element("Configuration");    // select root
                    XElement elm1 = root.Element("el1");    // get elm1 == null
                    XElement elm2 = root.Element("el2");    // get elm2 == null
    
    
    
    
    
                }
                catch (Exception e)
                {
                    _log.Error("Fail to load", e);
                }
            }
        }
