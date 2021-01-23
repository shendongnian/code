    protected void recipientsGrid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(App_Logic.Wrappers.DatabaseConnectionString()))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.Transaction = connection.BeginTransaction();
                try
                {
                    command.CommandText = " INSERT INTO NotificationParty(NotificationGroupID, FirstName, LastName, CellNumber, Active, UserCreated, DateCreated) VALUES " +
                        "(@NotificationGroupID, @FirstName, @LastName, @CellNumber, @Active, @UserCreated, GETDATE())";
    
                    command.Parameters.AddWithValue("@NotificationGroupID", Convert.ToInt32(Context.Session["NotificationGroupID"]));
                    command.Parameters.AddWithValue("@FirstName", e.NewValues["FirstName"]);
                    command.Parameters.AddWithValue("@LastName", e.NewValues["LastName"]);
                    command.Parameters.AddWithValue("@CellNumber", e.NewValues["CellNumber"]);
                    command.Parameters.AddWithValue("@Active", 1);
                    command.Parameters.AddWithValue("@UserCreated", Session["UID"]);
    
                    command.ExecuteNonQuery();
                    command.Transaction.Commit();
                }
                catch
                {
                    command.Transaction.Rollback();
                }
            }
        }
    
        recipientsGrid.CancelEdit();
        e.Cancel = true;
    }
