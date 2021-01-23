    // Row to copy from
    DataRow dr = JoblistDataSet.Tables["Joblist"].Rows[rowIndex];
    // Row that receives the values from source
    DataRow newrow = JoblistDataSet.Tables["Joblist"].NewRow();
    // Copy the ItemArray of the source row to the destination row
    // Note that this is not a reference copy.
    // Internally a new object array is created when you _get_ the ItemArray
    newrow.ItemArray = dr.ItemArray;
    // Change whateever you need to change
    newrow[0] = 99;
    // Add the new row into the datatable collection
    JoblistDataSet.Tables["Joblist"].Rows.Add(newrow);
