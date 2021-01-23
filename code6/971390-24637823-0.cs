    //creating some test datatable and agent list
    DataTable table = new DataTable();
    table.Columns.Add(new DataColumn("Agent_Code"));
    table.Columns.Add(new DataColumn("Agent_Name"));
    DataRow row1 = table.NewRow();
    DataRow row2 = table.NewRow();
    DataRow row3 = table.NewRow();
    DataRow row4 = table.NewRow();
    DataRow row5 = table.NewRow();
    row1["Agent_Code"] = 1;
    row2["Agent_Code"] = 2;
    row3["Agent_Code"] = 3;
    row4["Agent_Code"] = 4;
    row5["Agent_Code"] = 5;
    row1["Agent_Name"] = "A";
    row2["Agent_Name"] = "B";
    row3["Agent_Name"] = "C";
    row4["Agent_Name"] = "D";
    row5["Agent_Name"] = "E";
    table.Rows.Add(row1);
    table.Rows.Add(row2);
    table.Rows.Add(row3);
    table.Rows.Add(row4);
    table.Rows.Add(row5);
    List<int> Agent_Code = new List<int>();
    Agent_Code.Add(1);
    Agent_Code.Add(3);
    //finished test data
 
    //actual logic here
    List<DataRow> deleteRows = (from DataRow row in table.Rows
                                where !Agent_Code.Contains(int.Parse(row["Agent_Code"].ToString()))
                                select row).ToList();
    foreach (DataRow row in deleteRows)
    {
         table.Rows.Remove(row);
    }
