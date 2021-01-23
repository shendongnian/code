    public void MethodA(){
        using (var tran = Db.Database.BeginTransaction()){  
            try
            {
                MethodB();
                var tableARecord = new TableARecord();
                _context.TableAs.Add(tableARecord)
                Db.SaveChanges();
            }
            catch (Exception excp)
            {
                tran.Rollback();
                throw;
            }
        }
     }
     public int MethodB(){
        int ret = 0
        //exception happens when starting the transaction below
        // The transaction is already open, you should not open a new one.
        //do something else
        return ret;
      }
