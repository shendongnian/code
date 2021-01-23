    //Save object to XML file. Returns filename.
    public string SaveObjectAsXML(int id)
    {
        //however you get your EF context and disable proxy creation
        var db = GetContext(); 
        bool currentProxySetting = db.Configuration.ProxyCreationEnabled;
        db.Configuration.ProxyCreationEnabled = false;
        
        //get the data
        var item = db.GetItem(id); //retrieval be unique to your setup, but I have
                                   //a more generic solution if you need it. Make
                                   //sure you have all the sub items included
                                   //in your object or they won't be saved.
        db.Configuration.ProxyCreationEnabled = currentProxySetting;
        //if no item is found, do whatever needs to be done
        if (item == null)
        {                
            return string.Empty;
        }            
        //I actually write my data to a file so I can save states if needed, but you could
        //modify the method to just spit out the XML instead
        Directory.CreateDirectory(DATA_PATH); //make sure path exists to prevent write errors
        string path = $"{DATA_PATH}{id}{DATA_EXT}";
        var bf = new BinaryFormatter();
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            bf.Serialize(fs, repair);
        }
        
        return path;
    }
    //Load object from XML file. Returns ID.
    public int LoadXMLData(string path)
    {   
        //make sure the file exists
        if (!File.Exists(path))
        {
            throw new Exception("File not found.");
        }
        //load data from file
        try 
        { 
            using (FileStream fs = new FileStream(path, FileMode.Open)) 
            {
                var item = (YourItemType)new BinaryFormatter().Deserialize(fs);
                db.YourItemTypes.Add(item);
                db.SaveChanges();
                return item.Id;
            }
        }
        catch (Exception ex) {
            //Exceptions here are common when copying between databases where differences in config entries result in mis-matches
            throw;
        }
    }
