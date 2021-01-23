    DataSet dt = new DataSet();
    cmd = new SqlCommand();
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.CommandText = "sp_Accessories";
    cmd.Connection = con;
    
    var parameterList = new StringBuilder();
    for (int i = 0; i < items.Length; i++)
    {
        parameterList.Append(items[i] + ",");
    }
    var parameters= parameters.ToString().TrimEnd(',');
    cmd.Parameters.AddWithValue("@Combo", parameters);
    cmd.Parameters.AddRange(
        new SqlParameter[] {
            new SqlParameter("@Mode",mode),
        }}
