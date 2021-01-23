    listViewMevcutKullaniciListesi.Items.RemoveAt(listViewMevcutKullaniciListesi.SelectedIndices[0]);
    xDoc.Load("Accounts.xml");
                    foreach (XmlNode node in xDoc.SelectNodes("Accounts/Table"))
                    {
                        if (node.SelectSingleNode("User").InnerText == listViewMevcutKullaniciListesi.SelectedIndices[0].ToString())
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                    }
                xDoc.Save("Accounts.xml");
