            public void ConvertToDirectoryTree()
            {
                XmlReader xReader = XmlReader.Create(xmlDoc);
                while (!xReader.EOF)
                {
                    if (xReader.Name != "Asset")
                    {
                        xReader.ReadToFollowing("Asset");
                    }
                    if (!xReader.EOF)
                    {
                        XElement asset = (XElement)XElement.ReadFrom(xReader);
                        foreach (XElement testCase in asset.Elements("TestCase"))
                        {
                            //We check if the asset is a main branch folder
                            if (IsMainBranch((string)asset.Attribute("Name") + (string)asset.Attribute("Version")))
                            {
                                //If the folder exists already then add it inside this folder
                                if (Directory.Exists(root + (string)asset.Attribute("Name")))
                                {
                                   Directory.CreateDirectory(root + (string)asset.Attribute("Name") + "\\" + (string)testCase.Attribute("Version") + (string)testCase.Attribute("SubVersion"));
                                }
                                //Else we need to create the folder and then add it inside this folder
                                else
                                {
                                    Directory.CreateDirectory(root + (string)asset.Attribute("Name"));
                                    Directory.CreateDirectory(root + (string)asset.Attribute("Name") + "\\" + (string)testCase.Attribute("Version") + (string)testCase.Attribute("SubVersion"));
                                }
                            }
                            //If it is not a main branch folder then we need to handle the name differently
                            else
                            {
                                //If the folder exists already then add it inside this folder
                                if (Directory.Exists(root + (string)asset.Attribute("Name") + "-" + (string)asset.Attribute("Version")))
                                {
                                    Directory.CreateDirectory(root + (string)asset.Attribute("Name") + "-" + (string)asset.Attribute("Version") + "\\" + (string)testCase.Attribute("Version") + (string)testCase.Attribute("SubVersion"));
                                }
                                //Else we need to create the folder and then add it inside this folder
                                else
                                {
                                    Directory.CreateDirectory(root + (string)asset.Attribute("Name") + "-" + ((string)asset.Attribute("Version")).Replace(".", "_"));
                                    Directory.CreateDirectory(root + (string)asset.Attribute("Name") + "-" + (string)asset.Attribute("Version") + "\\" + (string)testCase.Attribute("Version") + (string)testCase.Attribute("SubVersion"));
                                }
                            }
                        }
                    }
                }
            }
