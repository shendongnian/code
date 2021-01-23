	// I am not 100% sold on my chosen name for the interface, if you like this idea change it to something more suitable
	public interface IIsPersisted {
		bool IsPersistedEntity{get;}
		int Key {get;}
	}
	public class SomeEntityModel : IIsPersisted{
		public int SomeEntityModelId {get;set;}
		/*some other properties*/
		
		bool IIsPersisted.IsPersistedEntity{get { return this.SomeEntityModelId > 0;}}
		int IIsPersisted.Key {get{return this.SomeEntityModelId;}}
	}
	
	public T UpdateOrCreate<T>(T updated) where T : class, IIsPersisted
	{
		if (updated == null)
			return null;
		if(updated.IsPersistedEntity)
		{
			T existing = _context.Set<T>().Find(updated.Key);
			if (existing != null)
			{
				context.Entry(existing).CurrentValues.SetValues(updated);
				context.SaveChanges();
			}
			return existing;
		}
		else
		{
			context.Set<T>().Add(updated);
			context.SaveChanges();
			return updated;
		}
	}
