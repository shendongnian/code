    private String filename = null;
    private void btnChooseFile_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();
        dlg.Multiselect = false;
        dlg.Filter = "XML documents (*.xml)|*.xml|All Files|*.*";
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            tbxXmlFile.Text = dlg.FileName;
            XmlDocument invDoc = new XmlDocument();
            invDoc.Load(dlg.FileName);
            ....
            ....
            this.filename = dlg.FileName;
        }
    }
    private void btnStore_Click(object sender, EventArgs e)
    {
        try
        {
            string cs = @"Data Source=localhost;Initial Catalog=db;integrated security=true;";
            using (SqlConnection sqlConn = new SqlConnection(cs))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(this.filename);
                ....
                ....
            }
        }
    }
