     DataTable dtloc = new DataTable();
     string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtfilepath.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
     string strloc = "select * from [sheet1$A5:A5]";
     OleDbCommand cmdloc = new OleDbCommand(strloc, con);
     con.Open();
     daloc.SelectCommand = cmdloc;
    string location = dtloc.Columns[0].ColumnName.ToString();
