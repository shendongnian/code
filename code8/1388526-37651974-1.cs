    public static DataSet Bindgrid_StoreInSQL(string path)
        {
           
           
                string strFileType = Path.GetExtension(path).ToLower();
                string connString = "";
                if (strFileType.Trim() == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                string query = "SELECT * FROM [Sheet1$]";
                OleDbConnection conn = new OleDbConnection(connString);
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable Exceldt = ds.Tables[0];
                
                //creating object of SqlBulkCopy    
                SqlBulkCopy objbulk = new SqlBulkCopy(OneStopMethods_Common.constring_Property);
                //assigning Destination table name    
                objbulk.DestinationTableName = "Tern_boq";
           
    
                objbulk.ColumnMappings.Add("ID", "ID");
                objbulk.ColumnMappings.Add("Bill_No", "Bill_No");
                objbulk.ColumnMappings.Add("Page_No", "Page_No");
                objbulk.ColumnMappings.Add("ItemNo", "ItemNo");
                objbulk.ColumnMappings.Add("Description", "Description");
                objbulk.ColumnMappings.Add("BOQ_Qty", "BOQ_Qty");
                objbulk.ColumnMappings.Add("UNIT", "UNIT");
                objbulk.ColumnMappings.Add("Category1", "Category1");
                objbulk.ColumnMappings.Add("Category2", "Category2");
                objbulk.ColumnMappings.Add("Category3", "Category3");
                objbulk.ColumnMappings.Add("Estimated_UnitRate", "Estimated_UnitRate");
                objbulk.ColumnMappings.Add("Estimated_Amount", "Estimated_Amount");
    
    
    
                //inserting Datatable Records to DataBase    
                conn.Open();
                objbulk.WriteToServer(Exceldt);
    
    
                SqlDatabase obj = new SqlDatabase(OneStopMethods_Common.constring_Property);
                string selquery = " select * from Tern_boq";
                return obj.ExecuteDataSet(CommandType.Text, selquery);
            
           
    
    
        }
