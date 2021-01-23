            string lstr = System.IO.File.ReadAllText(PathOfXML);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(lstr);
         
                XmlNodeList CFG_Group_DB_nodeList = doc.SelectNodes(@"/ConfData/CfgAgentGroup/CfgGroup/DBID");
                foreach (XmlNode n1 in CFG_Group_DB_nodeList)
                {
                     
                   if (n1.Attributes["value"].Value == "103")
                    {
                        Console.WriteLine(n1.Attributes["value"].Value);
                    }
                  
                }
