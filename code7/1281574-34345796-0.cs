    public DataTable RunMyQuery(...)
    {
        using(var connection = new SqlConnection(...))
        {
             connection.Open();
             ....
        }
    }
