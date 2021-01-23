    private void ReadXmlToGrid()
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(textBoxXML.Text);
            XmlNodeList listCodes = doc.SelectNodes("GenioCodes/Code");
            foreach (XmlNode oCode in listCodes)
            {
                int iRow = dataGridView.Rows.Add();
                dataGridView.Rows[iRow].Cells["Layer"].Value = oCode.Attributes["Layer"].Value;
                ushort iColourIndex = Convert.ToUInt16(oCode.Attributes["Colour"].Value);
                ComboboxColourItem ocbItem2 = null;
                foreach (ComboboxColourItem ocbItem in cboColumn.Items)
                {
                    if (ocbItem.Index == iColourIndex)
                    {
                        ocbItem2 = ocbItem;
                        break;
                    }
                }
                if (ocbItem2 == null)
                {
                    ocbItem2 = ComboboxColourItem.Create(iColourIndex);
                    cboColumn.Items.Add(ocbItem2);
                }
                dataGridView.Rows[iRow].Cells["Colour"].Value = ocbItem2;
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    private void SaveGridToXml()
    {
        XmlDocument doc = new XmlDocument();
        XmlElement codes = doc.CreateElement("GenioCodes");
        foreach(DataGridViewRow row in dataGridView.Rows)
        {
            if(row != null && !row.IsNewRow)
            {
                XmlElement code = doc.CreateElement("Code");
                code.SetAttribute("Layer", row.Cells["Layer"].Value.ToString());
                String strThisColour = row.Cells["Colour"].Value.ToString();
                bool bColourFound = false;
                foreach (ComboboxColourItem ocbItem in cboColumn.Items)
                {
                    if (ocbItem.Name == strThisColour)
                    {
                        code.SetAttribute("Colour", ocbItem.Index.ToString());
                        bColourFound = true;
                        break;
                    }
                }
                if(!bColourFound) // This should not happen
                    code.SetAttribute("Colour", "1"); // 1 is red
                codes.AppendChild(code);
            }
        }
        doc.AppendChild(codes);
        doc.Save(textBoxXML.Text);
    }
