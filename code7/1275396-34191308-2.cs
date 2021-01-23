        public class ChangeEventListener : IFlushEntityEventListener
    	{
    		public SetModificationTimeFlushEntityEventListener()
    		{
    			CurrentDateTimeProvider = () => DateTime.Now;
    		}
    
    		public void OnFlushEntity(FlushEntityEvent @event)
    		{
    			var entity = @event.Entity;
    			var entityEntry = @event.EntityEntry;
    
    			if (entityEntry.Status == Status.Deleted)
    			{
    				//raise event
    			}
    			var trackable = entity as ITrackModificationDate;
    			if (trackable == null)
    			{
    				return;
    			}
    			if (HasDirtyProperties(@event))
    			{
    				//raise event
    			}
    		}
    	
    	}
