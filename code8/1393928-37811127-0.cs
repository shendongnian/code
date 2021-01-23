    protected void btnSave_Click(object sender, EventArgs e)
    {
	    SPSecurity.RunWithElevatedPrivileges(delegate()
        {
            using (SPSite site = new SPSite("http://thiswebsite"))
            {
                using (SPWeb web = site.OpenWeb("/"))
                {
		            web.AllowUnsafeUpdates = true;
                    SPList app = web.Lists["projetoandre"];
                    SPListItemCollection collection = app.GetItems();
                    SPListItem item = collection.Add();
                    item["Title"] = txtTitle.Text;
                    item["Data"] = Convert.ToString(txtDataPretendida.Text);
                    item["Banco"] = Convert.ToString(ddlBanco.Text);
                    item["Confirmação"] = Convert.ToString(rdlUrgencia.Text);
                    Stream fs = FileUploadControl.PostedFile.InputStream;
                    byte[] fileContents = new byte[fs.Length];
                    fs.Read(fileContents, 0, (int)fs.Length);
                    fs.Close();
                    SPAttachmentCollection attachments = item.Attachments;
                    string fileName = "Ficheiro_" + Path.GetFileName(FileUploadControl.PostedFile.FileName);
                    attachments.Add(fileName, fileContents);
                    item.Update();
		            web.AllowUnsafeUpdates = false;
                }
            }
	    });	
    }
