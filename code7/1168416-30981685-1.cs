      private void GetProductDetails()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("C:\\Users\\ANDY\\Desktop\\XML Data\\Demo.xml");
                XmlNode node = doc.DocumentElement.SelectSingleNode("/users");
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("FirstName", typeof(string));
                dt.Columns.Add("LastName", typeof(string));
                dt.Columns.Add("ADD1", typeof(string));
                //dt.Columns.Add("DEPT", typeof(string)); 
                foreach (XmlNode NodeXml in node)
                {
                    DataRow dtrow = dt.NewRow();
                    //dtrow["Name"] = NodeXml["Name"].InnerText;
                    XmlElement companyElement = (XmlElement)NodeXml;
                    dtrow["Name"] = companyElement.GetElementsByTagName("Name")[0].InnerText;
                    dtrow["ID"] = companyElement.GetElementsByTagName("ID")[0].InnerText;
                    dtrow["FirstName"] = companyElement.GetElementsByTagName("FirstName")[0].InnerText;
                    dtrow["LastName"] = companyElement.GetElementsByTagName("LastName")[0].InnerText;
                    dtrow["ADD1"] = companyElement.GetElementsByTagName("ADD1")[0].InnerText;
                    //xmlCompanyID = companyElement.Attributes["ID"].InnerText;
                    //this is ANother Method you can bind ADDR.USING Child Method
                    //XmlNode AddrNode = node.SelectSingleNode("/users/DEPT/LOCATION");
                    //for (int i = 0; i < AddrNode.ChildNodes.Count; i++)
                    //{
                    //    if (AddrNode.ChildNodes[i].Name == "ADD1")
                    //    {
                    //        dtrow["ADD1"] = AddrNode["ADD1"].InnerText;
                    //    }
                    //}
                        
                      dt.Rows.Add(dtrow);
                }
                if (dt.Rows.Count > 0)
                {
                    RepDetails.DataSource = dt;
                    RepDetails.DataBind();
                }
                else
                {
                    RepDetails.DataSource = "";
                    RepDetails.DataBind();
                }
            }
