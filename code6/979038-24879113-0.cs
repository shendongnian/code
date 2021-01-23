    DataSet dt = new DataSet();
    cmd = new SqlCommand();
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.CommandText = "sp_Accessories";
    cmd.Connection = con;
    
    var parameters = new string[items.Length];
    for (int i = 0; i < items.Length; i++)
    {
        parameters[i] = string.Format("@Combo{0}", i);
        cmd.Parameters.AddWithValue(parameters[i], items[i]);
    }
    
    cmd.Parameters.AddRange(
        new SqlParameter[] {
            new SqlParameter("@Mode",mode),
        }}
