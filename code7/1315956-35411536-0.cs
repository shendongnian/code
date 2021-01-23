    public DataTable FillTable(string sql)
    {
        MySqlCommand sqlQuery = new MySqlCommand();
        cmd.Connection = ;// insert the connection details of the DB to transfer FROM
        cmd.CommandText = sql;
        DataTable dt = new DataTable();
        try
        { 
            conn.Open();                
            dt.Load(cmd.ExecuteReader());
            conn.Close();
        }
            catch (SqlException ex)
            {
                Console.WriteLine("fillTable: "+ ex.Message);
            }
        return dt;
    }
