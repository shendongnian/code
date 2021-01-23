    public ActionResult ExportToXML()
    {
        var lClist = db.LightControllers.Where(x => x.userID == LoggedInUser.id).OrderBy(x => x.controllerID).ToList();
       
        int baudIterator = 1;
        Networks n = new Networks();
        n.computer = "computer1";
        foreach(var i in lClist)
        {
    
            int numU = Convert.ToInt32(i.NumUniverses);
            for (int j = 0; j < numU; j++)
    
            {
                network netToAdd = new network();
                netToAdd.NetworkType = "E131";
                netToAdd.ComPort = i.ipaddress;
                netToAdd.BaudRate = baudIterator.ToString();
                netToAdd.MaxChannels = "510";
    
                n.network.Add(netToAdd);
                baudIterator++;
            }
        }
    
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        string path = Server.MapPath("~/XMLFiles/");
        string filename = "x_networks.xml";
        string filepath = Path.Combine(path, filename);
        if (System.IO.File.Exists(filepath))
        {
            System.IO.File.Delete(filepath);
        }
        XmlSerializer serial = new XmlSerializer(typeof(viewmodels.Networks));
        StreamWriter writer = new StreamWriter(filepath);
        serial.Serialize(writer, n, ns);
        writer.Close();
    
        return File(filepath, "application/xml", filename);
    }
