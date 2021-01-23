    string techId = "UMTS900";
    string coverageId = "SUBURBAN";
    int downloadSpeed = 0;
    int uploadSpeed = 0;
    
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(@"C:\....\DataSpeed.xml");
    XmlNodeList techTags = xmlDoc.GetElementsByTagName("Tech");
    foreach (XmlNode techTag in techTags)
    {
       if (techTag.Attributes["ID"].Value.Equals(techId,StringComparison.OrdinalIgnoreCase))
       {
          XmlNodeList coverageTags = techTag.ChildNodes;
          foreach (XmlNode coverageTag in coverageTags)
          {
             if (coverageTag.Attributes["ID"].Value.Equals(coverageId, StringComparison.OrdinalIgnoreCase))
             {
                downloadSpeed =Convert.ToInt16(coverageTag.ChildNodes[0].InnerText);
                uploadSpeed = Convert.ToInt16(coverageTag.ChildNodes[1].InnerText);
                break;
              }
           }
           break;
        }
     }
        if (downloadSpeed == 0 && uploadSpeed == 0)
        {
          Console.WriteLine("Specified Tech Id and Coverage Id not found");
        }
        else
        {
          Console.WriteLine("Download Speed is {0}. Upload Speed is {1}.",downloadSpeed,uploadSpeed);
       }
