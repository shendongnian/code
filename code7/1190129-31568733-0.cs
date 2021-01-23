    using (SqlConnection con = new SqlConnection(conString))
    {
        con.Open();
        var transaction = con.BeginTransaction();
        try
        {
            //Run first command
            //Run second command
            //If we have succeeded, commit the transaction
            transaction.Commit();
        }
        catch()
        {
            //Something went wrong, roll back
            transaction.Rollback();
        }
    }
