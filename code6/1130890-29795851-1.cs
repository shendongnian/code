    private void btnNewfile_Click(object sender, EventArgs e)
    {
         XmlDocument doc = new XmlDocument();
            doc.Load(PathSelection);
            XmlNode root = doc.DocumentElement;
            XmlNode myNode = root.SelectSingleNode("descendant::resheader[@name = 'version']/value");
            int iversion = Convert.ToInt32(myNode.InnerText);
            iversion++;
            lblversion.Text = iversion.ToString();
    }
