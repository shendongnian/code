    public void GenerateCsv(string filePath)
    {
    
      if (File.Exists("Details.xml")) {
            //Loading xml document with information
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Details.xml");       
    
            XmlNodeList dataNodes = xmlDoc.SelectNodes("//nameList"); //specify root element of your xml document      
    
            foreach(XmlNode node in dataNodes) {
               if(node.attributes != null)
               {
                   string id= node.Attributes["id"].Value;// reading attribute values 
                   if(node.HasChildNodes)
                   {
                     //loop through child nodes to get the data
                   }
               }
                     
            }
        } else {
            Console.WriteLine("No data to read");
        }
    
    
    }
