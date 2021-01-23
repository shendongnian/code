    private void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            {
                string strAsOfDate = dateTimePickerAsOfDate.Text;
                string strPriceDate = dateTimePickerPriceDate.Text;
                string strSetName = txtboxSet.Text;
                XmlDocument doc = new XmlDocument();
                doc.Load(strXMLfilepath);
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("ab", "CompanyName");
                XmlNode General;
                XmlNode root = doc.DocumentElement;
                General = root.SelectSingleNode("//ab:General", nsmgr);
                General["AsOfDate"].InnerText = strAsOfDate;
                General["PriceDate"].InnerText = strPriceDate;
                doc.Save(strXMLfilepath);
            }
        }
        catch (System.Exception excep)
        {
            MessageBox.Show(excep.Message);
        }
    }
