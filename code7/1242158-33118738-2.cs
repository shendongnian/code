    XmlNodeList xmlnodes;
    xmlnodes = xml.GetElementsByTagName("CruisePriceSummaryResponse");
    for (int i = 0; i < xmlnodes.Count; i++)
    {
        XmlNodeList rooms = xmlnodes[i].SelectNodes("RoomSize/CruisePriceSummaryRoomSize");
        for(int j = 0; j < rooms.Count; j++)
        {
            string bestFare = rooms[j].SelectSingleNode("BestFare/TotalPrice").InnerText;
            string fullFare = rooms[j].SelectSingleNode("FullFare/TotalPrice").InnerText;
    
            // do whatever you need
        }
    }
