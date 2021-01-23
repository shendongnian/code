    try
        {
            using (
                var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [Id]
                                                                        ,[FName]
                                                                        ,[LName]
                                                                        ,[DOB]
                                                                        ,[Notes]
                                                                        ,[PendingReview] 
                                                       FROM [dbo].[Users]",
                    connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    command.ExecuteReader();
                }
            }
        }
        catch (Exception e)
        {
            throw;
        }
    }
    private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
    {   
        SqlDependency dependency = sender as SqlDependency;
        if (dependency != null) dependency.OnChange -= dependency_OnChange;
        //Recall your SQLDependency setup method here.
        SetupDependency();
        JobHub.Show();
    }
    
