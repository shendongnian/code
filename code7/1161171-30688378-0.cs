    using(OleDbConnection con = DAL.GetConnection())
    {
        OleDbTransaction transaction = null;
        try
        {
            con.Open();
            transaction = con.BeginTransaction()
            
            string queryString1 = //SQL string
            OleDbCommand cmd1 = new OleDbCommand();
            {
                Connection = con,
                CommandType = CommandType.Text,
                CommandText = queryString1
            };
            string queryString2 = //SQL string
            OleDbCommand cmd2 = new OleDbCommand();
            {
                Connection = con,
                CommandType = CommandType.Text,
                CommandText = queryString2
            };
            int num1 = cmd.ExecuteNonQuery();
            int num2 = cmd.ExecuteNonQuery();
            if (num1 == 0 || num2 == 0)
            {
                //We didn't expect something to return 0, lets roll back
                transaction.Rollback();
                //send error message
                Response.Redirect("register.aspx?err=Error");
            }
            else
            {
                 //everything seems good, lets commit the transaction!
                 transaction.Commit();
                 Session["id"] = MyDB.GetUserId(uname);
                 Response.Redirect("home.aspx");
            }
        }
        catch(OleDbException ex)
        {
             try
             {
                 //something bad happened, lets roll everything back
                 transaction.Rollback();
                 Response.Redirect("register.aspx?err=Error");
             }
             catch
             {
                 //we don't really care about this catch statement
             }
        }
    }
