    static void main(string[] args)
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load("data.XML");
        XmlNodeList userNodes = xmldoc.SelectNodes("data.XML");
        
        // when you deserialize create a List<APISAVE>, basically adding what was already there to the list then in the save add the new obj to the list and save them all.
         
    }
    public static void SaveData(object obj, string Filename)
    {   
        list.Add(obj) // APISAVE objec
        // Serialize the list
        XmlSerializer sr = new XmlSerializer(list.GetType());
        TextWriter writer = new StreamWriter(Filename, true);
        sr.Serialize(writer, list);
        writer.Close();
    }
