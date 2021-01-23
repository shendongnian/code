    public myenum RepositoryMethod()
    {
       if(alreadyDone())
         return myenum.AlreadyDone;
      
       try
       {
           return myenum.Done;
       }
       catch(ex)
       {
           return myenum.ERROR;
       }
    } 
