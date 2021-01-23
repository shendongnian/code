    /// <summary>
    /// Inform an underlying data store to return a set of read-only entity instances.
    /// </summary>
    /// <typeparam name="TEntity">The entity type to return read-only entity instances of.</typeparam>
    public interface IEntityReader<out TEntity> where TEntity : Entity
    {
    	/// <summary>
    	/// Inform an underlying data store to return a set of read-only entity instances.
    	/// </summary>
    	/// <returns>IQueryable for set of read-only TEntity instances from an underlying data store.</returns>
    	IQueryable<TEntity> Query();
    }
    
    /// <summary>
    /// Informs an underlying  data store to accept sets of writeable entity instances.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntityWriter<in TEntity> where TEntity : Entity
    {
    	/// <summary>
    	/// Inform an underlying data store to return a single writable entity instance.
    	/// </summary>
    	/// <param name="primaryKey">Primary key value of the entity instance that the underlying data store should return.</param>
    	/// <returns>A single writable entity instance whose primary key matches the argument value(, if one exists in the underlying data store. Otherwise, null.</returns>
    	TEntity Get(object primaryKey);
    		
    	/// <summary>
    	/// Inform the underlying  data store that a new entity instance should be added to a set of entity instances.
    	/// </summary>
    	/// <param name="entity">Entity instance that should be added to the TEntity set by the underlying data store.</param>
    	void Create(TEntity entity);
    
    	/// <summary>
    	/// Inform the underlying data store that an existing entity instance should be permanently removed from its set of entity instances.
    	/// </summary>
    	/// <param name="entity">Entity instance that should be permanently removed from the TEntity set by the underlying data store.</param>
    	void Delete(TEntity entity);
    
    	/// <summary>
    	/// Inform the underlying data store that an existing entity instance's data state may have changed.
    	/// </summary>
    	/// <param name="entity">Entity instance whose data state may be different from that of the underlying data store.</param>
    	void Update(TEntity entity);
    }
    /// <summary>
    /// Synchronizes data state changes with an underlying data store.
    /// </summary>
    public interface IUnitOfWork
    {
    	/// <summary>
    	/// Saves changes tot the underlying data store
    	/// </summary>
    	void SaveChanges();
    }
