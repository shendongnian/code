    public void LoadStations()
    {
         string fileName = "data.xml";
         if (File.Exists(fileName))
         {
             XmlDocument xmlDoc = new XmlDocument();
    
             xmlDoc.Load(fileName);
             XmlNodeList stationNodes = xmlDoc.SelectNodes("//stations/station");
             foreach (XmlNode stationNode in stationNodes)
             {
                  listBox.Items.Add(stationNode); // by default, the InnerText will be displayed                
             }
    
             xmlDoc.Save(fileName); 
        }
        else
        {
             MessageBox.Show(" ");
        }
    }
