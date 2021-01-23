	public override void Execute()
	{
        ... // some importan stuff
        // here the UPDATE is executed
		if (!veto)
		{
			persister.Update(id, state, dirtyFields, hasDirtyCollection, 
                             previousState, previousVersion, instance, null, session);
		}
		EntityEntry entry = Session.PersistenceContext.GetEntry(instance);
		if (entry == null)
		{
			throw new AssertionFailure("Possible nonthreadsafe access to session");
		}
        // HERE we can see that NHibernate is going for GENERATED properties
        // imeditally 
		if (entry.Status == Status.Loaded || persister.IsVersionPropertyGenerated)
		{
			// get the updated snapshot of the entity state by cloning current state;
			// it is safe to copy in place, since by this time no-one else (should have)
			// has a reference  to the array
			TypeHelper.DeepCopy(state, persister.PropertyTypes,
                                persister.PropertyCheckability, state, Session);
			if (persister.HasUpdateGeneratedProperties)
			{
				// this entity defines property generation, so process those generated
				// values...
				persister.ProcessUpdateGeneratedProperties(id, instance, state, Session);
