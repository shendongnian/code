    string filename = "Streetlife Product Database.xlsx";
    string fullfilename = String.Format(@"//MILKYWAY/SO_Arc/template/{1}", Application.StartupPath, filename);
    string tempath = System.IO.Path.GetTempPath();
    string filenameTemp = String.Format("{0}.xlsx", System.IO.Path.GetTempFileName());
    System.IO.File.Copy(fullfilename, filenameTemp, true);
    string connetionString = String.Format(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source ={0};Extended Properties = ""Excel 12.0 Xml;HDR=YES;IMEX=1""", filenameTemp);
    using (OleDbConnection oledb = new OleDbConnection(connetionString))
    {
        try
        {
            oledb.Open();
        }
        catch (Exception ex)
        {
            oledb.Close();
            oledb.Dispose();
            MessageBox.Show("Error trying to read file: " + ex.Message);                    
        }
     }
