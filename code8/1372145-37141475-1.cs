                xmlFile.WriteElementString("id", (items.Length > 0 ? items[0] : ""));
                xmlFile.WriteElementString("mandant", (items.Length > 1 ? items[1] : ""));
                xmlFile.WriteElementString("datetime", (items.Length > 2 ? items[2] : ""));
                xmlFile.WriteElementString("t_m", (items.Length > 3 ? items[3] : ""));
                xmlFile.WriteElementString("user", (items.Length > 4 ? items[4] : ""));
                xmlFile.WriteElementString("action", (items.Length > 5 ? items[5] : ""));
                xmlFile.WriteElementString("info", (items.Length > 6 ? items[6] : ""));
