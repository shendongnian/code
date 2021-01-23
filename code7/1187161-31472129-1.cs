    /// <summary>
    /// Perform a select to retrieve the values of any generated properties
	/// back from the database, injecting these generated values into the
	/// given entity as well as writing this state to the persistence context.
	/// </summary>
	/// <remarks>
	/// Note, that because we update the persistence context here, callers
	/// need to take care that they have already written the initial snapshot
	/// to the persistence context before calling this method. 
	/// </remarks>
	/// <param name="id">The entity's id value.</param>
	/// <param name="entity">The entity for which to get the state.</param>
	/// <param name="state">The entity state (at the time of Save).</param>
	/// <param name="session">The session.</param>
	void ProcessUpdateGeneratedProperties(object id, object entity, 
             object[] state, ISessionImplementor session);
