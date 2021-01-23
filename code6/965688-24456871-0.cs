    class clsconnection
    {
        string connection = @"Data Source=server name;Initial Catalog=databasename;Integrated Security=True";
        public SqlConnection getconnection()
        {
            SqlConnection sql = new SqlConnection(connection);
            sql.Open();
            return sql;
        }
    }
}
