            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ContosoUniversity2ConnectionString"].ConnectionString);
            using (cn)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Department", cn))
                {
                    adapter.Fill(ds1.Department);
                    foreach (DataSet1.DepartmentRow row in ds1.Department.Rows)
                    {
                        if (row.Name != null)
                        {
                            Console.WriteLine(row.Name);
                        }
                    }
                }
            }
