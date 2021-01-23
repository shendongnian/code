    XmlNodeList xmlnode;
    xmlnode = xml.GetElementsByTagName("CruisePriceSummaryResponse");
    for (int i = 0; i < xmlnode.Count; i++)
    {
        XmlNodeList rooms = xmlnode.SelectNodes("RoomSize/CruisePriceSummaryRoomSize");
        for(int j = 0; j < rooms.Count; j++)
        {
            string bestFare = rooms[j].SelectSingleNode("BestFare").InnerText;
            string fullFare = rooms[j].SelectSingleNode("FullFare").InnerText;
    
            // do whatever you need
        }
    }
