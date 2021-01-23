        List<Info> infos = new List<Info>();
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ValidationType = ValidationType.Schema;
       // settings.Schemas.Add("urn:empl-hire", "hireDate.xsd");
        using (System.Xml.XmlReader reader = System.Xml.XmlReader.Create(xmlPath, settings))
        {            
            reader.MoveToContent();
          while(reader.ReadToFollowing("ServiceInformation"))
          {
              string serviceId = reader.GetAttribute("serviceId");
              string serviceUrl = "";
              if (reader.ReadToDescendant("ServiceURL"))
              {
                  serviceUrl = reader.ReadElementContentAsString();
              }
              Info info = new Info();
              info.ID = serviceId;
              info.Value1 = serviceUrl;
              infos.Add(info);
          }
                           
        }
        return infos;
