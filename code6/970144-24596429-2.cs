    private static void Read()
            {
                XmlReader xReader = XmlReader.Create("Save1.xml");
                while (xReader.Read())
                {
                    if (xReader.NodeType == XmlNodeType.Element)
                    {
                        switch (xReader.Name)
                        {
                            case "Zombies":
                                Vars.zombies = xReader.ReadElementContentAsDouble();
                            break;
                            case "Infected":
                                Vars.infected = xReader.ReadElementContentAsDouble();
                            break;
                            case "Wolfs":
                                Vars.wolfs = xReader.ReadElementContentAsDouble();
                            break;
                        }
                    }
                }
            }
