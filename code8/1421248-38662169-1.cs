    List<string> ids = new List<string>();
    
    string line;
    
    using (FileStream fs = new FileStream(@"\\path\\to\\file", FileMode.Open))
    using (StreamReader reader = new StreamReader(fs))
    {
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Contains("<div id="))
            {
                string[] split1 = line.Split('=');
                string[] split2 = split1[1].Split('>');
                //remove quotes
                ids.Add(split2[0].Replace('"', ' '));
            }
        }
    }
    
    //now look through the list
    foreach(string s in ids)
    {
        //do stuff
    
    }
