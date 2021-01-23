    using (SqlConnection conn = new SqlConnection("FULL CONNECTION STRING"))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT col1 FROM table 1", conn))
        {
            cmd.CommandType = CommandType.Text;
            DataTable dataTable = new DataTable();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
            {
                sqlDataAdapter.Fill(dataTable);
            }
            return dataTable;
        }
    }
