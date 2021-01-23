    public static IEnumerable<Account> GetAccountNumbersFromCustomerSSN
     (string CustomerSSN)
            {
    
                List<Account> accts = new List<Account>();
    
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings
                     ["TA_connectionstring"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGet_Account_Numbers_From_SSN", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
    
                        SqlParameter P1 = new SqlParameter
                           ("@CUSTOMER_SSN", DbType.String);
                        P1 = new SqlParameter
                           ("@CUSTOMER_SSN", DbType.String);
                        P1.Value = CustomerSSN;
                        cmd.Parameters.Add(P1);
    
                        SqlDataReader dr = cmd.ExecuteReader();
    
                        while (dr.Read())
                        {
                            yield return new Account
                            {
                                OriginalAcctNumber = 
                      dr["TABOAT_ACCOUNT_NUMBER"].ToString().TrimStart('0'),
                                FTBOATAcctNumber = 
                      dr["FTBOAT_ACCOUNT_NUMBER"].ToString().TrimStart('0'),
                                SSN = 
                      CustomerSSN.Substring(CustomerSSN.Length -4).PadLeft(CustomerSSN.Length, '*'),
                                CustomerName = 
                      dr["CUST_NAME"].ToString(),
                                ProductType = 
                      dr["TRGT_PROD"].ToString()
                            };
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionUtility.LogException(ex, "GetCustomerSSN()");
    
                }
            }
