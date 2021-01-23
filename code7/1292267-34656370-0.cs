    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace DataOperations_cs
    {
        public class BackendOperations
        {
            public string ConnectionString { get; set; }
            public DataTable DataTable { get; set; }
            public List<string> ContactTitles { get; set; }
            public Exception Exception { get; set; }
    
            public bool HasException
            {
                get
                {
                    return this.Exception != null;
                }
            }
    
            public bool RetrieveAllRecords()
            {
                this.DataTable = new DataTable();
                try
                {
                    using (SqlConnection cn = new SqlConnection { ConnectionString = this.ConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandType = CommandType.StoredProcedure, CommandText = "dbo.[SelectAllCustomers]" })
                        {
                            try
                            {
                                cn.Open();
                            }
                            catch (SqlException sqlex)
                            {
    
                                if (sqlex.Message.Contains("Could not open a connection"))
                                {
                                    this.Exception = sqlex;
                                    return false;
                                }
                            }
                            
                            this.DataTable.Load(cmd.ExecuteReader());
                        }
                    }
    
                    if (ContactTitles == null)
                    {
                        RetrieveContactTitles();
                    }
    
                    this.Exception = null;
                    return true;
                }
                catch (Exception ex)
                {
                    this.Exception = ex;
                    return false;
                }
            }
    
            public bool RetrieveAllRecordsbyContactTitle(string contactType)
            {
                this.DataTable = new DataTable();
                try
                {
                    using (SqlConnection cn = new SqlConnection { ConnectionString = this.ConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandType = CommandType.StoredProcedure, CommandText = "dbo.ContactByType" })
                        {
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@ContactTitleType", SqlDbType = SqlDbType.NVarChar });
                            cmd.Parameters["@ContactTitleType"].Value = contactType;
                            cn.Open();
                            this.DataTable.Load(cmd.ExecuteReader());
                        }
                    }
    
                    this.Exception = null;
                    return true;
                }
                catch (Exception ex)
                {
                    this.Exception = ex;
                    return false;
                }
            }
    
            public bool RetrieveContactTitles()
            {
                if (ContactTitles != null)
                {
                    return true;
                }
    
                try
                {
                    using (SqlConnection cn = new SqlConnection { ConnectionString = this.ConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandType = CommandType.StoredProcedure, CommandText = "dbo.[SelectContactTitles]" })
                        {
                            cn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                this.ContactTitles = new List<string>();
                                while (reader.Read())
                                {
                                    this.ContactTitles.Add(reader.GetString(0));
                                }
                            }
                        }
                    }
    
                    this.Exception = null;
                    return true;
                }
                catch (Exception ex)
                {
                    this.Exception = ex;
                    return false;
                }
            }
    
            public int AddCustomer(string CompanyName, string ContactName, string ContactTitle)
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection { ConnectionString = this.ConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandType = CommandType.StoredProcedure, CommandText = "dbo.InsertCustomer" })
                        {
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@CompanyName", SqlDbType = SqlDbType.NVarChar });
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@ContactName", SqlDbType = SqlDbType.NVarChar });
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@ContactTitle", SqlDbType = SqlDbType.NVarChar });
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@Identity", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
    
                            cmd.Parameters["@CompanyName"].Value = CompanyName;
                            cmd.Parameters["@ContactName"].Value = ContactName;
                            cmd.Parameters["@ContactTitle"].Value = ContactTitle;
                            cn.Open();
                            var affected = cmd.ExecuteScalar();
    
                            this.Exception = null;
                            return Convert.ToInt32(cmd.Parameters["@Identity"].Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Exception = ex;
                    return -1;
                }
            }
    
            public bool RemoveCustomer(int Indentifier)
            {
                using (SqlConnection cn = new SqlConnection { ConnectionString = this.ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandType = CommandType.StoredProcedure, CommandText = "dbo.[DeleteCustomer]" })
                    {
                        cmd.Parameters.Add(new SqlParameter { ParameterName = "@Identity", SqlDbType = SqlDbType.Int });
                        cmd.Parameters.Add(new SqlParameter { ParameterName = "@flag", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output });
    
                        cmd.Parameters["@Identity"].Value = Indentifier;
                        cmd.Parameters["@flag"].Value = 0;
    
                        try
                        {
                            cn.Open();
                            var affected = cmd.ExecuteNonQuery();
                            this.Exception = null;
                            if (Convert.ToBoolean(cmd.Parameters["@flag"].Value))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            this.Exception = ex;
                            return false;
                        }
                    }
                }
            }
    
            public bool UpdateCustomer(int PrimaryKey, string CompanyName, string ContactName, string ContactTitle)
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection { ConnectionString = this.ConnectionString })
                    {
                        using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandType = CommandType.StoredProcedure, CommandText = "dbo.[UpateCustomer]" })
                        {
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@CompanyName", SqlDbType = SqlDbType.NVarChar });
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@ContactName", SqlDbType = SqlDbType.NVarChar });
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@ContactTitle", SqlDbType = SqlDbType.NVarChar });
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@Identity", SqlDbType = SqlDbType.Int });
                            cmd.Parameters.Add(new SqlParameter { ParameterName = "@flag", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output });
    
                            cmd.Parameters["@CompanyName"].Value = CompanyName;
                            cmd.Parameters["@ContactName"].Value = ContactName;
                            cmd.Parameters["@ContactTitle"].Value = ContactTitle;
                            cmd.Parameters["@Identity"].Value = PrimaryKey;
                            cmd.Parameters["@flag"].Value = 0;
    
                            cn.Open();
                            var affected = cmd.ExecuteNonQuery();
                            this.Exception = null;
    
                            if (Convert.ToBoolean(cmd.Parameters["@flag"].Value))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Exception = ex;
                    return false;
                }
            }
        }
    }
