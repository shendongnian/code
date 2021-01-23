    var results = from t1 in dtEmployee.AsEnumerable()
                  join t2 in dtReport.AsEnumerable() 
                    on t1.Field<int>("agent_id") equals t2.Field<int>("agent_id")
                  select new { agent_id, agent_name, t2sum };
                         
    // Now we can construct new DataTable
    
    DataTable result = new DataTable() ;
    result.Columns.Add("agent_id", typeof(System.Int32));
    result.Columns.Add("Name", typeof(System.String));
    result.Columns.Add("sum", typeof(float));
    
    foreach(var dr in results )
    {
        DataRow newRow = results.NewRow();
        newRow["agent_id"] = dr.t1.Field<int>("agent_id");
        newRow["agent_name"] = dr.t1.Field<string>("agent_name");
        newRow["sum"] = dr.t1.Field<float>("sum");
    
        // When all columns have been filled in then add the row to the table
        results.Rows.Add(newRow);
    } 
