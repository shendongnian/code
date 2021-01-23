    try
                {
                    using (OleDbConnection connection = new OleDbConnection("my connection string"))
                    {
                        //Open connection
                        connection.Open();
    
                        //Create new command
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = connection;
                        //Create command text
                        cmd.CommandText =
                            "INSERT INTO studentBillRecords " +
                            "(StudentName, Department, StudentLevel, AccomodationStatus, SemesterBill, PreviousBalance, TotalBill) VALUES " +
                            "(@StudentName, @Department, @StudentLevel, @AccomodationStatus, @SemesterBill, @PreviousBalance, @TotalBill)";
    
                        // Add names paremeters
                        cmd.Parameters.AddRange(new OleDbParameter[]
                        {
                           new OleDbParameter("@StudentName", txtSRstudentName.Text),
                           new OleDbParameter("@Department", cmbSRDepartment.Text),
                           new OleDbParameter("@StudentLevel", cmbSRLevel.Text),
                           new OleDbParameter("@AccomodationStatus", cmbSRAccomodationStatus.Text),
                           new OleDbParameter("@SemesterBill", txtSRSemesterBill.Text),
                           new OleDbParameter("@PreviousBalance", txtSRPreviousBalance.Text),
                           new OleDbParameter("@TotalBill", txtSRTotalBill.Text)
                       });
    
                        //Execute Query
                        cmd.ExecuteNonQuery();
    
                        //No need to close because we are using "using"
                    }
                }
                catch (OleDbException ex)
                {
                    //If an exception occurs let's print it out to console
                    Console.WriteLine("ERROR: " + ex.ToString());
                    throw;
                }
