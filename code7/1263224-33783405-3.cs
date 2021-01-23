    public int GetMaxno(decimal Licenseno)
    {
         using(var con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=True; Initial Catalog=sudipDB;")
         using(var cmd = con.CreateCommand())
         {
            cmd.CommandText = "select Max(Value) from tblv where Licenseno = @licenseno";
            cmd.Parameters.Add("@licenseno", SqlDbType.Decimal).Value = Licenseno;
            con.Open();
            return (int)cmd.ExecuteScalar();
         }
    }
