    //Create a command object
    SqlCommand cmd = new SqlCommand();
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Text = "spr_Reports_JobsBreakdown4";
    cmd.Connection = sqlConnection;
    
    //Create its parameters
    SqlParameter param1 = new SqlParameter("@user", SqlDbType.NVarChar);
    param1.value = "someusername";
    
    SqlParameter param2 = new SqlParameter("@datefrom", SqlDbType.DateTime);
    param2.value = DateTime.Now - 1; //this should result in yesterday date/time
    
    SqlParameter param3 = new SqlParameter("@datefto", SqlDbType.DateTime);
    param3.value = DateTime.Now;
    
    //Add parameters to the command
    cmd.Parameters.Add(param1);
    cmd.Parameters.Add(param2);
    cmd.Parameters.Add(param3);
    
    //Execute your command
    var res = cmd.ExecuteScalar();
