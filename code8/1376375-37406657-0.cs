            List<ItemLists> chkListIIS = new List<ItemLists>();
            chkListIIS = Serverlist();
            int x = 50;
            int y = 0;
            int p = 240;
            foreach (ItemLists serviceItem in chkListIIS)
            {
                y = y + 18;
                string itemValue = serviceItem.Value;
                string itemName = serviceItem.Name;
                CheckBox box1 = new CheckBox();
                Label lbl = new Label();
                box1.Text = itemName;
                box1.Font = new Font(FontFamily.GenericSansSerif, 8F);
                lbl.Font = new Font(FontFamily.GenericSansSerif, 8F);
                //lbl.Text = CheckStatus(itemName, itemValue);
                box1.Tag = itemValue;
                lbl.Text = "Status";
                lbl.AutoSize = true;
                box1.AutoSize = true;
                gbIis.Controls.Add(box1);
                gbIis.Controls.Add(lbl);
                box1.Location = new Point(x, y);
                lbl.Location = new Point(p, y);
            }
        }` private List<ItemLists> Serverlist()
        {
            xmldoc.Load(xmlPath);
            XmlNodeList nodelist = xmldoc.SelectNodes("servers");
            List<ItemLists> chkListServer = new List<ItemLists>();
            {
                foreach (XmlNode node in nodelist.Item(0))
                {
                    foreach (XmlNode childElement in node)
                    {
                        string serverApp = childElement.ChildNodes[4].InnerText;
                        string serverName = childElement.Attributes["Name"].Value;
                        if (childElement.Attributes["Name"].Value != "vmxxhegepda01"
                            && childElement.Attributes["Name"].Value != "vmxxhegepqa01"
                            && childElement.Attributes["Name"].Value != "vmxxhegeppa01")
                        {
                            chkListServer.Add(new ItemLists() { Name = serverName, Value = serverApp });
                        }
                    }
                }
            }
            return chkListServer;
        }`enter code here`
