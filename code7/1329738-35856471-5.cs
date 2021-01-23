            public List<Career> SelectCareer()
            {
                return To("connectionString", "sql for careers", ToCarrer);
            }
            public List<Brand> SelectBrand()
            {
                return To("connectionString", "sql for brands", ToBrand);
            }
            private static Brand ToBrand(SqlDataReader arg)
            {
                throw new NotImplementedException("Similar to ToCarrer");
            }
            private static Career ToCarrer(SqlDataReader dr)
            {
                return new Career()
                {
                    CareerId = Convert.ToInt32(dr[0]),
                    CareerName = (string)dr[1].ToString(),
                    CareerIsAct = (string)dr[2].ToString(),
                    CareerNote = (string)dr[3].ToString(),
                };
            }
            private static List<T> To<T>(string connectionString, string sql, Func<SqlDataReader, T> funct)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    var SQL = sql;
                    var cmd = new SqlCommand(SQL, con);
                    var lista = new List<T>();
                    con.Open();
                    try
                    {
                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            lista.Add(funct(dr));
                        }
                        dr.Close();
                    }
                    finally
                    {
                        con.Close();
                    }
                    return lista;
                }
            }
