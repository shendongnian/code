    string filename = System.IO.Path.GetFileName(FileUpload1.FileName);
    if (FileUpload1.HasFile == true) {
	string fp = System.IO.Path.GetDirectoryName(FileUpload1.FileName);
	string full = "C:\\Users\\user\\Documents\\" + filename;
	TextBox1.Text = full;
	//FileUpload1.SaveAs(Server.MapPath("Files/" + filename))
	try {
		string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=full;Extended Properties=Excel 8.0;HDR=YES;";
		string cmdStr = "Select * from [Sheet1$]";
		using (OleDbConnection oledbconn = new OleDbConnection(connStr)) {
			using (OleDbCommand oledbcmd = new OleDbCommand(cmdStr, oledbconn)) {
				oledbconn.Open();
				OleDbDataAdapter oledbda = new OleDbDataAdapter(oledbcmd);
				DataSet ds = new DataSet();
				oledbda.Fill(ds);
				//save to an SQL Database
				oledbconn.Close();
			}
		}
	} catch (Exception ex) {
		TextBox2.Text = ex.ToString();
	}
    }
