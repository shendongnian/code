            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("sample.xml");
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                int rowval = row.Index;
                String propertyID = (dgv[0, rowval].Value.ToString());
                String propertyName = (dgv[1, rowval].Value.ToString());
                var propertyNode = xDoc.SelectNodes("//Class[@Name='" + getCurClass() + "']/Property[@Id='" + propertyID + "']/following-sibling::Property");
                if (propertyNode != null)
                {
                    var confirmMessage = "Are you sure to delete propert set \"" + propertyName + "\" ?";
                    if (MessageBox.Show(confirmMessage, "Confirm Deletion!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (XmlNode p in propertyNode)
                        {
                            int value = 0;
                            int.TryParse(p.Attributes["Id"].Value, out value);
                            value = value - 1;
                            String newValue = value.ToString();
                            p.Attributes["Id"].Value = newValue;
                            xDoc.Save("sample.xml");
                        }
                    }
                }
                var selectedRow = xDoc.SelectSingleNode("//Class[@Name='" + getCurClass() + "']/Property[@Name='" + propertyName + "']");
                selectedRow.ParentNode.RemoveChild(selectedRow);
                xDoc.Save("sample.xml");
            }
