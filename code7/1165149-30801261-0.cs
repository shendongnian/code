    string s = "<Data><Client><id>ID1</id><Details><detail1>1</detail1><detail2>2</detail2></Details><Details><detail1>3</detail1><detail2>4</detail2></Details></Client><Client><id>ID2</id><Details><detail1>1</detail1><detail2>2</detail2></Details></Client><Client><id>ID3</id><Details><detail1>1</detail1><detail2>2</detail2></Details></Client></Data>";
    XmlDocument xDoc = new XmlDocument();
    xDoc.LoadXml(s);
    //Store nodes in variables
    XmlNodeList Client, Details;
    //Get all clients
    Client = xDoc.SelectNodes("/Data/Client");
    foreach (XmlNode cn in Client)
    {
        //Get all Details parents
        Details = cn.SelectNodes("Details");
        foreach (XmlNode dn in Details)
        {
            //Get all "sub" detail of parents, or details values
            foreach (XmlNode n in dn.ChildNodes)
            {
                Console.WriteLine(n.InnerText);
            }
        }
    }
