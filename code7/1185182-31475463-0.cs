    public EventHandler SavingChangesEventHandler
            {
                set
                {
                    (((System.Data.Entity.Infrastructure.IObjectContextAdapter)this).ObjectContext).SavingChanges += value;
                } 
            }
