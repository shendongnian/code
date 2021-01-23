    XmlDocument xDoc = new XmlDocument();
    xDoc.Load("sample.xml");
    
    foreach (DataGridViewRow row in dgv.SelectedRows)
    {
        var propertyId = dgv[0, row.Index].Value.ToString();
        var propertyName = dgv[1, row.Index].Value.ToString();
        var propertyNode = xDoc.SelectSingleNode("//Class[@Name='" + getCurClass() + "']/Property[@Name='" + propertyName + "']");
        
        if (propertyNode != null) {
            var remainingProperties = propertyNode.SelectNodes("./following-sibling::Property");
            var confirmMessage = "Are you sure to delete propert set \"" + propertyName + "\" ?";
            if (MessageBox.Show(confirmMessage, "Confirm Deletion!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                propertyNode.ParentNode.RemoveChild(propertyNode);
            }
            foreach (var p in remainingProperties)
            {
                int value = 0;
                int.TryParse(p.Attributes["Id"].Value, out value);
                p.Attributes["Id"].Value = value - 1;
            }
            xDoc.Save("sample.xml");
            dgv.Rows.RemoveAt(rowval);
            dgv.ClearSelection();
            getProperties();
        }
    }
