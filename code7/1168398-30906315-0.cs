    DataTable table = new DataTable();
    table.Columns.Add("Name");
    table.Columns.Add("Address");
    
    table.Rows.Add("Shan", "ADC Street");
    
    DataTable table2 = new DataTable();
    table2.Columns.Add("Name");
    table2.Columns.Add("Address");
    table2.Rows.Add("Raj", "EFG Street");
    
    table2.Merge(table,true);
    
    Console.WriteLine(table2.Rows.Count);      //2
    Console.WriteLine(table2.Rows[0]["Name"]); //Raj
    Console.WriteLine(table2.Rows[1]["Name"]); //Shan
