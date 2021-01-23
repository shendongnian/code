    // place this code inside CommitAsTransaction
    using (TransactionScope scope = new TransactionScope())
    {
         Boolean AllOK = true;
         SqlConnection connection = this.CreateSQLConnection();
         try
         {
             connection.Open()
         }
         catch (Exception e)
         {
           // deal with it how you need to
           AllOK = false;
         }
         if (AllOK)
         {
            foreach(SQlCommand cmd in Commands)
            {
                try
                {
                     cmd.Connection = connection;
                     cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                   // Deal with it.. 
                   AllOK = false;
                   break;
                }
            }
            if (AllOK)
            {
               scope.Complete();
               try
               {
                   connection.Close();
               }
               catch (Exception e)
               {
                 // deal with it
               }
            }
        }
    }
                
