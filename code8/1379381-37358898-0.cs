    public static void UpdatePayment(string cid,string txnno)
    {
        // add using block to dispose of DbContext after you're done with it
        using( DivorceCasesContext db = new DivorceCasesContext() )
        {
            DivorceCases dc = db.DivorceCase.Include(x => x.t)
                // use .Find( <id> ) when searching for an entity by PK
                //  avoids the need to call .SingleOrDefault() and also has the
                //  added benefit of retrieving a cached entity if it exists
                .Find( cid );
    
                // take care of your null ref problem
                if( dc.t == null )
                {
                    dc.t = new Transactions();
                }
                
                // simplify null/empty string check
                if( string.IsNullOrEmpty( dc.t.txn_id1 ) )
                {
                    dc.t.txn_id1 = txnno;
                    dc.t.amount1 = amount.ToString();
                    dc.t.date1 = DateTime.Now.ToString();
                }
                else
                {
                    dc.t.txn_id2 = txnno;
                    dc.t.amount2 = amount.ToString();
                    dc.t.date2 = DateTime.Now.ToString();
                }
    
                // this is not needed - dc is already attached to the context
                //  (unless you're doing something nonstandard by default
                //   within your DbContext)
                //db.Set<DivorceCases>().Attach(dc);
                //db.Entry(dc).State = EntityState.Modified;
    
                db.SaveChanges();
            }
        }
    }
