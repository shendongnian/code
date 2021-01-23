	XmlNodeList nodeListPrs = root.SelectNodes("/ns2:serviceOrder/resourceFacingService/physicalResource", nsmgr);
                foreach (XmlNode book in nodeListPrs)
                {
                    string prsName = book["prName"].InnerText;
                    try
                    {
                        nodeListPrsCh = book.SelectSingleNode("physicalResourceCharacteristic").SelectNodes("characteristic");
                        foreach (XmlNode characteristics in nodeListPrsCh)
                        {
                            dataGridView3.Rows.Add();
                            dataGridView3.Rows[i].Cells[0].Value = prsName;
                            try { string name = characteristics["name"].InnerText; dataGridView3.Rows[i].Cells[1].Value = name; }
                            catch { dataGridView3.Rows[i].Cells[1].Value = "-"; }
                            try { string value = characteristics["value"].InnerText; dataGridView3.Rows[i].Cells[2].Value = value; }
                            catch { dataGridView3.Rows[i].Cells[2].Value = "-"; }
                            i = i + 1;
                        }
                    }
                    catch
                    {
                        dataGridView3.Rows.Add();
                        dataGridView3.Rows[i].Cells[0].Value = prsName;
                        dataGridView3.Rows[i].Cells[1].Value = "-";
                        dataGridView3.Rows[i].Cells[2].Value = "-";
                        i = i + 1;
                    }
                }
