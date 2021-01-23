    XmlDocument xDoc = new XmlDocument();
    xDoc.Load("sample.xml");
    
    foreach (DataGridViewRow row in dgv.SelectedRows)
    {
        var propertyId = dgv[0, row.Index].Value.ToString();
        var propertyName = dgv[1, row.Index].Value.ToString();
        var propertyNode = xDoc.SelectSingleNode("//Class[@Name='" + getCurClass() + "']/Property[@Name='" + propertyName + "']");
        
        if (propertyNode != null) {
            var remainingProperties = propertyNode.SelectNodes("./following-sibling::Property");
            var confirmMessage = "Are you sure to delete property set \"" + propertyName + "\" ?";
            if (MessageBox.Show(confirmMessage, "Confirm Deletion!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (XmlNode p in remainingProperties)
                {
                    var idAttr = p.Attributes["Id"];
                    if (idAttr != null) {
                        int value = 0;
                        if (int.TryParse(idAttr.Value, out value)) {;
                            idAttr.Value = (value - 1).ToString();
                        }
                    }
                }
                propertyNode.ParentNode.RemoveChild(propertyNode);
            }
            xDoc.Save("sample.xml");
            dgv.Rows.RemoveAt(rowval);
            dgv.ClearSelection();
            getProperties();
        }
    }
