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
        private static void PrintXmlPlayers(XmlNode players)
        {
            foreach (XmlNode player in players.SelectNodes("player"))
            {
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
        private static void TestXml()
        {
            // path of document is relative to executable
            const string xmlPath = "../../Players.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNode players = doc["players"];
            PrintXmlPlayers(players);
            XmlNode alice = players.SelectSingleNode("player[@name='Alice']");
            string aliceOldString = alice["strength"].InnerText;
            alice["strength"].InnerText = "10";
            doc.Save(xmlPath);
            PrintXmlPlayers(players);
            alice["strength"].InnerText = aliceOldString;
            doc.Save(xmlPath);
        }
