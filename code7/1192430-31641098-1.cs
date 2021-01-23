    // Make a clone of the source datatable
    DataTable dataTable2 = dataTable1.Clone();
    // Loop through each row in the source datatable and check for key
    foreach (DataRow dr in dataTable1.Rows)
    {
        string key = dr["Key"].ToString();
        DataRow dRow = dataTable2.NewRow();
        switch (key)
        {
            case "Key5Value":
                // Rename actual key value if needed
                dr["Key"] = "Key Rename if needed";
                // Set new datarow item array to current row in loop item array
                dRow.ItemArray = dr.ItemArray;
                // Add datarow to desired position in dataTable 2
                dataTable2.Rows.InsertAt(dRow, 0);
                break;
            case "Key6Value":
                dr["Key"] = "Key Rename if needed";
                dRow.ItemArray = dr.ItemArray;
                dataTable2.Rows.InsertAt(dRow, 1);
                break;
            case "Key1Value":
                dr["Key"] = "Key Rename if needed";
                dRow.ItemArray = dr.ItemArray;
                dataTable2.Rows.InsertAt(dRow, 2);
                break;
            case "Key2Value":
                dr["Key"] = "Key Rename if needed";
                dRow.ItemArray = dr.ItemArray;
                dataTable2.Rows.InsertAt(dRow, 3);
                break;
            case "Key4Value":
                dr["Key"] = "Key Rename if needed";
                dRow.ItemArray = dr.ItemArray;
                dataTable2.Rows.InsertAt(dRow, 4);
                break;
            case "Key3Value":
                dr["Key"] = "Key Rename if needed";
                dRow.ItemArray = dr.ItemArray;
                dataTable2.Rows.InsertAt(dRow, 5);
                break;
        }
    }
