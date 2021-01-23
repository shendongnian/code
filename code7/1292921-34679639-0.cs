    XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("path_here");
            XmlNodeList covers = xmlDoc.SelectNodes("/songCover/item");
            XmlNodeList names = xmlDoc.SelectNodes("/songName/item");
            XmlNodeList years = xmlDoc.SelectNodes("/releaseYear/item");
            
            for(int i=0;i<covers.Count; i++)
            {
                Console.WriteLine("[ "+ covers[i].Value +", " + names[i].Value + ", "+ years[i].Value  + " ]");
            }
