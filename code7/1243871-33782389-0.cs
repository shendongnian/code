    private System.Data.DataTable call()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string FilePath = Server.MapPath("~/Reports/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(FilePath);
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
    
            string conStr = "";
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                    break;
    
                case ".xlsx": //Excel 07
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                    break;
            }
            conStr = String.Format(conStr, FilePath, "YES");
            OleDbConnection connExcel = new OleDbConnection(conStr);
    
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
    
            cmdExcel.Connection = connExcel;
    
            connExcel.Open();
            System.Data.DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();
    
            connExcel.Open();
   
    
            cmdExcel.CommandText = "SELECT [ColumnName1] , [ColumnName2]  From [report$A10:U16384] where  [ColumnName1] is not null";//any Condition
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
    
           
            return dt;
        }
