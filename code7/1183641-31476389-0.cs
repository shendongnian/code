    public override void Edit(MwbePaymentMethod entityToUpdate)
            {
                DbSet.Attach(entityToUpdate);
                Context.Entry(entityToUpdate).State = EntityState.Modified;
    
                if(entityToUpdate.BillingAddress != null)
                {
                  DbContext.Attach(entityToUpdate.BillingAddress);
                  Context.Entry(entityToUpdate.BillingAddress).State = EntityState.Modified;
                }
    
                if(entityToUpdate.Currency != null)
                {
                  DbContext.Attach(entityToUpdate.Currency);
                  Context.Entry(entityToUpdate.Currency).State = EntityState.Modified;
                }
    
                //manual update of  properties
                //Context.Entry(entityToUpdate.BillingAddress).State = EntityState.Modified;
                //Context.Entry(entityToUpdate.Currency).State = EntityState.Unchanged;
            }
