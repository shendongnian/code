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
    string[] Agent_Code = new string[] { "1", "3" };
    //finished test data
 
    //actual logic here
    StringBuilder filterBuilder = new StringBuilder();
    for (int i = 0; i < Agent_Code.Length; i++)
    {
         if (i != 0) filterBuilder.Append(" OR ");
         filterBuilder.Append("Agent_Code = '");
         filterBuilder.Append(Agent_Code[i]);
         filterBuilder.Append("'");
    }
    DataView view = new DataView(table, filterBuilder.ToString(), "Agent_Code", DataViewRowState.CurrentRows);
    DataTable newTable = view.ToTable();
