    public DataSet ExcelToDS(string Path, string sheetname)
            {
                string xlsConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";Extended Properties=Excel 8.0;";
                string xlsxConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties=Excel 12.0";
                using (OleDbConnection conn = new OleDbConnection(xlsxConn))
                {
                    conn.Open();
                    string strExcel = "select * from [" + sheetname + "$]";
                    OleDbDataAdapter oledbda = new OleDbDataAdapter(strExcel, xlsxConn);
                    DataSet ds = new DataSet();
                    oledbda.Fill(ds, sheetname);
                    conn.Close();
                    return ds;
                }
            }
