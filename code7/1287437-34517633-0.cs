    private static DataTable getReadingTableFromSchema()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDbConnnectionString"].ConnectionString))
        {
            string sql = "SELECT * FROM [Readings]";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            da.FillSchema(dtbl, SchemaType.Source);
            return dtbl;
        }
    }
