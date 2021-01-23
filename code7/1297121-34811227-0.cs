    foreach (XmlNode node in doc.DocumentElement) 
    {
        string name = node.Attributes[0].Value;
        int age = int.Parse(node["Age"].InnerText);
        bool isMale = bool.Parse(node["IsMale"].InnerText);
        
        var likedPerson = node.SelectSingleNode("LikedPerson");
            
        if (likedPerson != null){
            string name = likedPerson.Attributes[0].Value;
            //age, gender, etc.        
        }        
    }
