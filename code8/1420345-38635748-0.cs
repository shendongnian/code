    OpenFileDialog dlg = new OpenFileDialog();
    dlg.Filter = "Database Files|*.mdb";
    if (dlg.ShowDialog() == DialogResult.OK) {
        string dbfile = dlg.FileName;
        string connectstring = string.format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}";Persist Security Info=False;, dbfile);
        
         using (OleDbConnection con = new OleDbConnection(connectstring)) {
             //... do your database operations here
         }
        
    }
