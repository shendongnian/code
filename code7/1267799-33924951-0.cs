        public class SqlHelper
        {
            public static IDataReader ExecuteReader(string procedure, params SqlParameter[] commandParameters)
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(procedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(commandParameters);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                            da.Fill(dt);
                        return dt.CreateDataReader();
                    }
                }
            }
        }
        public class DishesTypes
        {
            public static IDataReader DishesTypesSelectAll()
            {
                return SqlHelper.ExecuteReader("DishesTypesSelectAllRows");//name of procedure
            }
        }
