    using (var context = new YourContext()) 
                { 
                    using (var dbContextTransaction = context.Database.BeginTransaction()) 
                    { 
                        try 
                        { 
                          //Your logic here
                            context.SaveChanges(); 
     
                            dbContextTransaction.Commit(); 
                        } 
                        catch (Exception) 
                        { 
                            dbContextTransaction.Rollback(); 
                        } 
                    } 
                } 
