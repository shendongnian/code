    public TEntity Find(params object[] keyValues)
    {
      this.InternalContext.ObjectContext.AsyncMonitor.EnsureNotEntered();
      this.InternalContext.DetectChanges(false);
      WrappedEntityKey key = new WrappedEntityKey(this.EntitySet, this.EntitySetName, keyValues, "keyValues");
      object obj = this.FindInStateManager(key) ?? this.FindInStore(key, "keyValues");
      if (obj != null && !(obj is TEntity))
        throw Error.DbSet_WrongEntityTypeFound((object) obj.GetType().Name, (object) typeof (TEntity).Name);
      else
        return (TEntity) obj;
    }
    /// <summary>
    /// Finds an entity with the given primary key values.
    ///             If an entity with the given primary key values exists in the context, then it is
    ///             returned immediately without making a request to the store.  Otherwise, a request
    ///             is made to the store for an entity with the given primary key values and this entity,
    ///             if found, is attached to the context and returned.  If no entity is found in the
    ///             context or the store, then null is returned.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The ordering of composite key values is as defined in the EDM, which is in turn as defined in
    ///             the designer, by the Code First fluent API, or by the DataMember attribute.
    /// 
    /// </remarks>
    /// <param name="keyValues">The values of the primary key for the entity to be found. </param>
    /// <returns>
    /// The entity found, or null.
    /// </returns>
    /// <exception cref="T:System.InvalidOperationException">Thrown if multiple entities exist in the context with the primary key values given.</exception><exception cref="T:System.InvalidOperationException">Thrown if the type of entity is not part of the data model for this context.</exception><exception cref="T:System.InvalidOperationException">Thrown if the types of the key values do not match the types of the key values for the entity type to be found.</exception><exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
    public virtual TEntity Find(params object[] keyValues)
    {
      return this.GetInternalSetWithCheck("Find").Find(keyValues);
    }
