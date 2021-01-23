    XElement xmlDoc = XElement.Load(@"C:\Users\username\Desktop\Noname1.xml");
            IEnumerable<XElement> myPlayers = from myP in xmlDoc.Elements("Player")
                                              where (string)myP.Element("Name") == "PoopNUG"
                                              select myP;
            foreach (XElement player in myPlayers)
            {
                string name = player.Element("Name").Value;
                string tag = player.Element("PlayerTag").Value;
            }
