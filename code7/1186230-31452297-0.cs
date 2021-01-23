    string path = System.AppDomain.CurrentDomain.BaseDirectory + "LogInUpdater.xml";
        XDocument doc;
                    doc = new XDocument(
                                    new XElement("LogUpdate",
                                    new XElement("Id",
                                        new XAttribute("Id", IdL.Text)),
                                    new XElement("Name",
                                        new XAttribute("Name", NameL.Text)),
                                    new XElement("Password",
                                        new XAttribute("Password", txtPassword)),
                                    new XElement("Department",
                                        new XAttribute("Department", DeptL.Text)),
                                    new XElement("Time",
                                        new XAttribute("Time", x.LogTime.ToString())),
                                    new XElement("TotalTime",
                                        new XAttribute("TotalTime", x.TotalTime.ToString())),
                                    new XElement("Log",
                                        new XAttribute("Log", x.Log.ToString()))));
                    SaveLoginInfoToDisk(doc);
