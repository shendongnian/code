    con.Open();
    foreach (DataRow dr in dt.Rows)
    {
     string insertCommand = "Insert INTO DrugAudit (Category, SubCategory, Quantity, MedName, OrderTrigger, Issues, Price, Notes, Summary, Recommendations, Alternative) VALUES (";
    //dr.SetModified();
    foreach (DataColumn dc in dt.Columns)
    {
        insertCommand += "'" + dr[dc].ToString() + "',"
    }
    int lastIndex = insertCommand.LastIndexOf(',');
    insertCommand = insertCommand.Remove(lastIndex);
    insertCommand += ");";
    cmd=new System.Data.OleDb.OleDbCommand(insertCommand,con);
    int i = cmd.ExecuteNonQuery();
    }
