    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    
    namespace SQL_Server_TwoList
    {
        public class DataOperations
        {
            public List<string> Titles { get; set; }
            public List<string> Names { get; set; }
    
            /// <summary>
            /// Trigger code to load two list above
            /// </summary>
            public DataOperations()
            {
                Titles = new List<string>();
                Names = new List<string>();
            }
            public bool LoadData()
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                    {
                        string commandText = @"
                        SELECT [TitleOfCourtesy] + ' ' + [LastName] + ' ' + [FirstName] As FullName FROM [NORTHWND.MDF].[dbo].[Employees]; 
                        SELECT DISTINCT [Title] FROM [NORTHWND.MDF].[dbo].[Employees];";
    
                        using (SqlCommand cmd = new SqlCommand(commandText, cn))
                        {
    
                            cn.Open();
    
                            SqlDataReader reader = cmd.ExecuteReader();
    
                            // get results into first list from first select
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Names.Add(reader.GetString(0));
                                }
    
                                // move on to second select
                                reader.NextResult();
    
                                // get results into first list from first select
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        Titles.Add(reader.GetString(0));
                                    }
                                }
                            }
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
