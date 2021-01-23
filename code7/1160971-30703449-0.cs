    public string LoadPhoneNumber()
        {        
             XDocument xmlDoc = XDocument.Load(Application.StartupPath + "/AppUsers/Users.xml");
                var items = from item in xmlDoc.Elements("Users").Elements("user")
                            where item != null &&(item.Attribute("author").Value == "Home Owner")
    
                            select item;
                foreach (var item in items)
                {                  
                      string phoneNum=item.Element("mobile").Value.ToString();
                      return PhoneNum;      
    
                }
                return LoadPhoneNumber();
        }
