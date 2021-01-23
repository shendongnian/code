     public List<string[]> GetRunningOrderOnTable(string tableNo, int shopid)
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    string xmlFilePath = @"C:\inetpub\wwwroot\ShopAPI\XmlData\RunningTables.xml";
                    //string xmlFilePath = HttpContext.Current.Server.MapPath("~/XmlData/RunningTables.xml");
          // Option 1
                    //                FileStream xmlFile = new FileStream(xmlFilePath, FileMode.Open,
                    //FileAccess.Read, FileShare.Read);
                    //                xmlDoc.Load(xmlFile);
          // Option 2
                    using (Stream s = File.OpenRead(xmlFilePath))
                    {
                        xmlDoc.Load(s);
                    }
                    //xmlDoc.Load(xmlFilePath);
                    List<string[]> st = new List<string[]>();
                    XmlNodeList userNodes = xmlDoc.SelectNodes("//Tables/Table");
                    if (userNodes != null)
                    {
                        foreach (XmlNode userNode in userNodes)
                        {
                            string tblNo = userNode.Attributes["No"].Value;
                            string sid = userNode.Attributes["ShopID"].Value;
                            if (tblNo == tableNo && sid == shopid.ToString())
                            {
                                string[] str = new string[5];
                                str[0] = userNode.Attributes["No"].Value;
                                str[1] = userNode.InnerText; // OrderNumber
                                str[2] = userNode.Attributes["OrderID"].Value;
                                str[3] = userNode.Attributes["OrderedOn"].Value;
                                str[4] = userNode.Attributes["TotalAmount"].Value;
                                st.Add(str);
                            }
                        }
                    }
                    else return new List<string[]>();
                    return st;
                }
                catch (Exception ex)
                {
                    
                    CustomLogging.Log("RunningTables.xml GetRunningOrderOnTable Error " + ex.StackTrace, LoggingType.XMLRead);
                    return new List<string[]>();
                }
            }
