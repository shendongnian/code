                   if (!xReader.EOF)
                    {
                        XElement asset = (XElement)XElement.ReadFrom(xReader);
                        string aName = (string)asset.Attribute("Name");
                        string aVersion = (string)asset.Attribute("Version");
                        foreach(XElement testCase in asset.Elements("TestCase"))
                        {
                            string tName = (string)testCase.Attribute("Name");
                            string tVersion = (string)testCase.Attribute("Version");
                            string tSubVersion = (string)testCase.Attribute("SubVersion");
                        }
                    }
