    public bool OnPreInsert(PreInsertEvent @event)
    {
    
        if(@event.Entity is MyEnity)
        {            
            var myEntity = @event.Entity as MyEnity;
    
    
            string newKey = GetCustomKey(...);
    
                myEntity.myId = newKey;                
                var property = typeof(AbstractPreDatabaseOperationEvent).GetProperty("Id");
                if (property != null)
                {
                    property.SetValue(@event,newKey);
                    // HERE we do call Set
                    // to udpate the state
                    Set(@event.Persister, @event.State, "Id", newKey);
                }
            }
    
            return false;
        }
    }
    private void Set(IEntityPersister persister, object[] state
           , string propertyName, object value)
    {
        var index = Array.IndexOf(persister.PropertyNames, propertyName);
        if (index == -1)
            return;
        state[index] = value;
    }
