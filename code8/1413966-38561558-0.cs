      string curAssembly = Assembly.GetExecutingAssembly().Location;
                string FolderPath = Path.GetDirectoryName(curAssembly);
                string[] files = Directory.GetFiles(FolderPath).Where(x => x.EndsWith(".config")).ToArray();
                foreach (string item in files)
                {
                    XmlDocument XmlDoc = new XmlDocument();
                    XmlDoc.Load(item);
                    foreach (XmlElement xElement in XmlDoc.DocumentElement)
                    {
                        if (xElement.Name == "connectionStrings")
                        {
                            foreach (XmlElement xChild in xElement)
                            {
                                if (xChild.Attributes.Count > 1 && xChild.Attributes[0].Value == ConfigSectionName)
                                {
                                    xChild.Attributes[1].Value = "Data Source=" + cmbDatasource.Text + ";Initial Catalog=" + cmbDatabaseName.Text + ";UID=" + txtUserName.Text + ";password=" + txtPassword.Text + ";Integrated Security = false;";
                                    Connectionstring = xChild.Attributes[1].Value;
                                }
                            }
                        }
                    }
                    XmlDoc.Save(item);
                }
