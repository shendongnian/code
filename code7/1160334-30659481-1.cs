    DataTable dt = new DataTable();
    dt.Columns.Add("Id", typeof(int));
    //Add rows in datatable with values
    DataRow dr = dt.NewRow();
    dr["Id"] = 10;
    dt.Rows.Add(dr);
    //Now pass this table to SP as parameter
    SqlParameter parameter = new SqlParameter();
    parameter.ParameterName = "@DataToSearch"; 
    parameter.SqlDbType = System.Data.SqlDbType.Structured; 
    parameter.Value = dt;
   
