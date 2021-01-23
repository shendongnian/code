    protected void recipientsGrid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
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
                    command.CommandText = " UPDATE NotificationParty SET FirstName = @FirstName, LastName = @LastName, CellNumber = @CellNumber, UserModified = @UserModified, DateModified = GETDATE() WHERE ID = @ID";
    
                    command.Parameters.AddWithValue("@ID", e.Keys[0]);
                    command.Parameters.AddWithValue("@FirstName", e.NewValues["FirstName"]);
                    command.Parameters.AddWithValue("@LastName", e.NewValues["LastName"]);
                    command.Parameters.AddWithValue("@CellNumber", e.NewValues["CellNumber"]);
                    command.Parameters.AddWithValue("@UserModified", Session["UID"]);
    
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
