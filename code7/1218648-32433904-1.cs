    private void addFavourite(String url, string name)
    {
       XmlDocument myXml = new XmlDocument();       
       if (File.Exists(favXml))
       {         
          myXml.Load(favXml); <-- load your XML file here          
       }
       else
       {
          XmlElement root = myXml.CreateElement("favourites");
          myXml.AppendChild(root);
       }
       
        XmlElement el = myXml.CreateElement("favorit");
        el.SetAttribute("url", url);
        el.InnerText = name;
        myXml.DocumentElement.AppendChild(el);
        myXml.Save(favXml); 
    }
