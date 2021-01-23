    Parallel.For(0, 100, delegate(int i)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {                          
            connection.Open();
            SqlCommand cmd = new SqlCommand();
                         
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
     
            cmd.CommandText = string.Format("insert into Service_LoadTest(id,ServiceCallcount) values ({0},'Call_{1}')", i, i);                               
            cmd.ExecuteNonQuery();
        }
    });
