    // Returns a DataTable of ALL suppliers
    private DataTable GetSuppliers()
    {
        return GetSuppliers(0);
    }
    // Returns a DataTable of the given supplier
    private DataTable GetSuppliers(int supplierId)
    {
        using (var connection = new SqlCommand())
        {
            connection.ConnectionString = @"Data Source= arlene-pc; Initial Catalog= PennyburnGreg; Integrated Security=True";
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                if (supplierId == 0)
                { 
                    command.commandText = "SELECT * FROM Supplier";
                }
                else
                {
                    command.commandText = "SELECT * FROM Supplier WHERE SupplierId=@id";
                    command.Parameters.AddWithValue("@id", supplierId);
                }
                using (var adapter = new SqlDataAdapter())
                {
                    using (var ds = new DataSet())
                    {
                        adapter.SelectCommand = command;
                        adapter.Fill(ds);
                        if (ds.Tables.Count > 0)
                            return ds.Tables[0];
                    }
                }
            }
        }
        return null;
    }
