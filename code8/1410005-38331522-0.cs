            const int max_try = 5;
            int i = max_try;
            while (i-- > 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(
                        "INSERT INTO LoggerLoanForm VALUES(@Session, @Form, @DateStamp, @LoanNumber)", connection))
                        {
                            command.Parameters.Add(new SqlParameter("Session", llf.SesssionId));
                            command.Parameters.Add(new SqlParameter("Form", llf.Form));
                            command.Parameters.Add(new SqlParameter("DateStamp", llf.DateStamp));
                            command.Parameters.Add(new SqlParameter("LoanNumber", llf.LoanNumber));
                            command.ExecuteNonQuery();
                            i = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (i == 0) 
                                AppInsightHelper.TrackException(ex);
                          System.Threading.Thread.Sleep(50);
                        
                    }
                }
            }
