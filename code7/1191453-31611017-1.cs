    private void AddToXmlLogInInfoDoc()
            {
                var x = this.DataContext as ViewModel.ViewModel;
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "users.xml";
                XDocument  doc;
                doc = XDocument.Load(path);
                XElement ele = new XElement("LogUpdate",
                        new XElement("Id",
                            new XAttribute("Id", IdL.Text)),
                        new XElement("Name",
                            new XAttribute("Name", NameL.Text)),
                        new XElement("Password",
                            new XAttribute("Password", txtPassword.Password.ToString())),
                        new XElement("Department",
                            new XAttribute("Department", DeptL.Text)),
                        new XElement("Time",
                            new XAttribute("Time", x.LogTime.ToString())),
                        new XElement("TotalTime",
                            new XAttribute("TotalTime", x.TotalTime.ToString())),
                        new XElement("Log",
                            new XAttribute("Log", x.Log.ToString())));
                doc.Root.Add(ele);
                document.Save
            }
