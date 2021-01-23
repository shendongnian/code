    private bool SetCommands(string CommandName, string CommandInfo, string UserLevel)
    {
        if (GetCommand(CommandName) == "none")
        {
            XDocument doc = new XDocument();
    
            if (File.Exists(XmlFileLocation))
                doc = XDocument.Load(XmlFileLocation);
            
            var users = doc.Root.Element("Users");
            if (users == null)
            {
                users = new XElement("Users");
                doc.Add(users);
            }
            users.Add(new XElement(UserLevel, new XElement(CommandName.Remove(0, 1), CommandInfo)));
            doc.Save(XmlFileLocation);
            return true;
        }
        else
        {
            return false;
        }
    }
