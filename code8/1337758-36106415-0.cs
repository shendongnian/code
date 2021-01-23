    public void Export(List<Booking> bookings)
    {
        string path =Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "zeitbuchungen.xml");
        //This block is what you need to add
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        //////////////////
        using (XmlWriter xmlWriter = xmlNavigator.AppendChild())
        {
            XmlSerializer xmlSerializer =( doc, new XmlRootAttribute("Bookings"));
            
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            xmlSerializer.Serialize(xmlWriter, bookings);
            fs.Close();
        }
        }
        xmlDocument.Save(path);
    }
  
