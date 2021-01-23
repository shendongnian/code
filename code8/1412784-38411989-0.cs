    string _name = string.Empty;
            OpenFileDialog OFD = new OpenFileDialog();
            if(OFD.ShowDialog()==DialogResult.OK)
            {
                _name = OFD.FileName;
            }
            var pathstring = System.IO.Path.GetDirectoryName(_name);
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+pathstring+";Extended Properties='Text;HDR=YES;FMT=Delimited;'";
            con.Open();
            da = new OleDbDataAdapter("Select * from "+System.IO.Path.GetFileName(_name), con);
            dt = new DataTable();
            da.Fill(dt); con.Close();
