    private void SqlbulkCopy(DataTable dt)
            {
    
                if (dt.Rows.Count > 0)
                {
                    string consString = ConfigurationManager.ConnectionStrings["Bulkcopy"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(consString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.leads";
    
                            //[OPTIONAL]: Map the DataTable columns with that of the database table
    
                            sqlBulkCopy.ColumnMappings.Add("Currunt_Company", "CuCompany");
                            sqlBulkCopy.ColumnMappings.Add("Currunt_Product", "CuProduct");
                            sqlBulkCopy.ColumnMappings.Add("Quantity", "Quantity");
                            sqlBulkCopy.ColumnMappings.Add("Unit_Price", "UnitPrice");
                            sqlBulkCopy.ColumnMappings.Add("Total_Price", "TotalPrice");
                            sqlBulkCopy.ColumnMappings.Add("Contect_Person", "ContectPerson");
    
                            con.Open();
                            sqlBulkCopy.WriteToServer(dt);
                            con.Close();
                        }
                    }
                }
            }
