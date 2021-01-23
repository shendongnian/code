            using (XmlReader xr = XmlReader.Create("../../XMLFile1.xml"))
            {
                xr.MoveToContent();
                XNamespace ab = xr.LookupNamespace("ab");
                while (xr.Read())
                {
                    while (xr.NodeType == XmlNodeType.Element && xr.NamespaceURI == ab && xr.LocalName == "pin")
                    {
                        XElement pin = (XElement)XNode.ReadFrom(xr);
                        var data = from atts in pin.Elements(ab + "attributes") select new {
                            levelid = (string)atts.Element(ab + "levelid"),
                            levelUl = (string)atts.Element(ab + "levelUl"),
                            primaryCode = (string)atts.Element(ab + "primaryCode"),
                            primaryPower = (string)atts.Element(ab + "primaryPower")
                        };
                        Console.WriteLine("levelId: {0}; levelUl: {1}, ...", data.First().levelid, data.First().levelUl);
                    }
                }
            }
