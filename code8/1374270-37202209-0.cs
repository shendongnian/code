    protected void Upload_Click(object sender, EventArgs e)
    {         
        FileUpload file1 = (FileUpload)DetailsView1.FindControl("FileUpload1");
        
        DataTable table = new DataTable();
        table.Columns.Add("FileName", typeof(string));
        table.Columns.Add("Bytes", typeof(byte[]));
        foreach (HttpPostedFile postedFile in file1.PostedFiles)
        {
            string filename = Path.GetFileName(postedFile.FileName);
    
            using (Stream fs = postedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    table.Rows.Add(fileName, bytes);
                }
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
