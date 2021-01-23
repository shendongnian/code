    public class MyContext : DbContext
    {
        public MyContext()        
        {
            //Handle the SavingChanges event:
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.SavingChanges += objectContext_SavingChanges;
        }
        private void objectContext_SavingChanges(object sender, EventArgs e)
        {
            var context = (ObjectContext)sender;
            context.DetectChanges();
            foreach (var entry in context.ObjectStateManager
                            .GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                if (entry.Entity is IAudit)
                {
                    if (entry.IsRelationship) continue;
                    var auditEntry = (IAudit)entry.Entity;
                    if (entry.State == EntityState.Modified)
                    {
                        auditEntry.UpdatedOn = DateTime.Now;
                        auditEntry.UpdatedBy = GetUser();
                    }
                }
            }
        }
    }
