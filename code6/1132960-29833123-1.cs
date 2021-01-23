    private class Player
    {
       public string Name { get; set; }
       public int Speed { get; set; }
       public int Strength { get; set; }
       public int Stamina { get; set; }
       public override string ToString()
       {
           return "Name: " + Name + Environment.NewLine +
                  "Speed: " + Speed + Environment.NewLine +
                  "Strength: " + Strength + Environment.NewLine +
                  "Stamina: " + Stamina + Environment.NewLine;
       }
    }
    private static void TestXml()
    {
        // path of document is relative to executable
        XmlDocument doc = new XmlDocument();
        doc.Load("../../Players.xml");
        // index into your XmlDocument by node name
        XmlNode players = doc["players"];
        // get all players inside the players node
        foreach (XmlNode player in players.SelectNodes("player"))
        {
            // take note of XML library methods
            string playerName = player.Attributes["name"].InnerText;
            int playerSpeed = XmlConvert.ToInt32(player["speed"].InnerText);
            int playerStrength = XmlConvert.ToInt32(player["strength"].InnerText);
            int playerStamina = XmlConvert.ToInt32(player["stamina"].InnerText);
            Player aPlayer = new Player
            {
                Name = playerName,
                Speed = playerSpeed,
                Strength = playerStrength,
                Stamina = playerStamina
            };
            Console.WriteLine(aPlayer);
        }
    }
