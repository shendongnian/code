     private void Cleanup(bool fromDispose)
            {
                try
                {
                    if (Transactions && transaction != null && !transaction.WasCommitted && !transaction.WasRolledBack)
                    {
                        transaction.Rollback();
                     
                    }
                }catch (Exception e) 
                {}
                try{
                    if (!IsStateless && session.IsOpen)
                    {
                        session.Close();
                        session.Dispose();
                    }
                       else if (session.IsOpen)
                    {
                        statelessSession.Close();
                        statelessSession.Dispose();
    
                    }
                        } catch (Exception e)
                { }
                  
                }
               
            
    
            public void Dispose()
            {
                Cleanup(true);
            }
    
            ~BaseUnitOfWork()
            {
                Cleanup(false);
            }
    
