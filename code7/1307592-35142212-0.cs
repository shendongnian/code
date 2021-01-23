    public class DataOperations
    {
        public DataTable LoadCustomers()
        {
            DataTable dtCustomers = new DataTable();
    
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                string commandText = @"SELECT [Identfier], [CompanyName],[ContactName],[ContactTitle] FROM [NORTHWND1.MDF].[dbo].[Customers]";
    
                using (SqlCommand cmd = new SqlCommand(commandText, cn))
                {
                    try
                    {
                        cn.Open();
                        dtCustomers.Load(cmd.ExecuteReader());
                        dtCustomers.Columns["Identfier"].ColumnMapping = MappingType.Hidden;
                        dtCustomers.Columns["ContactTitle"].ColumnMapping = MappingType.Hidden;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
    
            return dtCustomers;
        }
    }
