    // this line is declaring a new variable named 'dt' 
    // and assigning it an instance of a new DataTable
    DataTable dt = new DataTable();
    // this line is immediately overwriting the new DataTable 
    // assigned to 'dt' with the DataTable returned from 'GetDataTableFromDGV'
    dt = GetDataTableFromDGV(DGV);
