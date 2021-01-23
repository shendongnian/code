    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    namespace ConsoleApplicationMapper
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Career> careers = SelectSomething("connectionString", "sql for careers", ToCarrer);
                List<Brand> brands = SelectSomething("connectionString", "sql for brands", ToBrand);
                Console.ReadLine();
            }
            private static Brand ToBrand(SqlDataReader arg)
            {
                throw new NotImplementedException();
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
            public static List<T> SelectSomething<T>(string connectionString, string sql, Func<SqlDataReader, T> funct)
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
        }
    }
