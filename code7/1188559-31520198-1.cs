            public static DataTable ToDataTable<T>(this IQueryable<T> query, DataContext context)
            {
                if (query == null)
                {
                    throw new ArgumentNullException("query");
                }
    
                IDbCommand cmd = context.GetCommand(query.AsQueryable());
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = (SqlCommand)cmd;
                DataTable dt = new DataTable("sd");
                try
                {
                    cmd.Connection.Open();
                    adapter.FillSchema(dt, SchemaType.Source);
                    adapter.Fill(dt);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return dt;
            }
