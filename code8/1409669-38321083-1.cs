    foreach(DataRow dRow in Usersdt.Rows)
    {
        DataTable destinationTable = null;
    
        if (dRow.Field<string>("UserType") == "student")
            destinationTable = Studentsdt;
        else if (dRow.Field<string>("UserType") == "Faculty")
            destinationTable = Facultydt;
        else
            continue;
        
        // copy the row skipping the last column as required
        object[] rowData = new object[dRow.ItemArray.Length - 1];
        Array.ConstrainedCopy(dRow.ItemArray, 0, rowData, 0, rowData.Length);
        destinationTable.Rows.Add(rowData);
    }
