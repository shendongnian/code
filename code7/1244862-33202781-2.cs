        public List<IProvider> GetProviders(List<IProvider> providers, IFactory factory)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Providers.usp_GetProviders";
            SQLDatabase db = new SQLDatabase();
            using(cmd.Connection = db.GetConnection())
            {
                
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    IProvider provider = factory.GetProvider();
                    MapDbToEntity(rdr, provider);
                    providers.Add(provider);
                }
            }
            return providers;
        }
