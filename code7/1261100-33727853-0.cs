     //...
    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
    {
        oda.Fill(dtExcelData);
    }
    excel_con.Close();
    dtExcelData.Columns.Add("Id", typeof(int));
        
    int i = 0;
    foreach(DataRow dr in dtExcelData.Rows)
    {
        dr["Id"] = ++i;  
    }
    //...
