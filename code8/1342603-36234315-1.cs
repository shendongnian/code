    try
    {
       using(TransactionScope scope = new TransactionScope())
       using(FBConnection con = new FBConnection('connectionstringhere'))
       {
         con.Open();
         ...
         scope.Complete();
       }
    }
    catch(FBException ex)
    {
       // No rollback needed in case of exceptions. 
       // Exiting from the using statement without Scope.Complete
       // will cause the rollback
      MessageBox.Show(ex.Message);
    }
