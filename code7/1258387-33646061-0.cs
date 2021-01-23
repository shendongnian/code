    class Transaction
     {
         public Transaction()
         {
            string FirstQuery = "INSERT INTO Table1 VALUES('Vineeth',24)";
            string SecondQuery = "INSERT INTO Table2 VALUES('HisAddress')";
            int ErrorVar = 0;
            using (SqlConnection con = new SqlConnection("your connection string"))
            {
                try
                {
                    SqlCommand ObjCommand = new SqlCommand(FirstQuery, con);
                    SqlTransaction trans;
                    con.Open();
                    trans = con.BeginTransaction();
                    ObjCommand.Transaction = trans;
                    //Executing first query
                //What ever operation on your database do here
                ObjCommand.ExecuteNonQuery();  //Exected first query
                ObjCommand.CommandText = SecondQuery;
                ObjCommand.ExecuteNonQuery();  //Exected first query
                //Everything gone fine. So commiting
                ObjCommand.Transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error but we are rollbacking");
                ObjCommand.Transaction.Rollback();
            }
            con.Close();
        }
    }
    }
