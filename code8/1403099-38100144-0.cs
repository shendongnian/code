    ora.Open();
    using (OracleCommand cmd = new OracleCommand())
    {
       cmd.Connection = ora;
       cmd.BindByName = true; 
    
       cmd.CommandText = "update test set name = :name";
       OracleParameter name = new OracleParameter("name", OracleDbType.Varchar2);
       name.Value = "test";
       cmd.Parameters.Add(name); // add the name parameter, not "a" object.
    
       cmd.ExecuteNonQuery();
    }
