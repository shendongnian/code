    /// <summary>
    /// Base controller to support AllowedSelectProperties 
    /// </summary>
    /// <typeparam name="TContext">You application DbContext that this Controller will operate against</typeparam>
    /// <typeparam name="TEntity">The entity type that this controller is bound to</typeparam>
    /// <typeparam name="TKey">The type of the key property for this TEntity</typeparam>
    public abstract class MyODataController<TContext, TEntity, TKey> : ODataController
        where TContext : DbContext
        where TEntity : class
    {
        public string AllowedSelectProperties { get; set; }
        protected static ODataValidationSettings _validationSettings = new ODataValidationSettings() { MaxExpansionDepth = 5 };
        private TContext _db = null;
        /// <summary>
        /// Get a persistant DB Context per request
        /// </summary>
        /// <remarks>Inheriting classes can override RefreshDBContext to handle how a context is created</remarks>
        protected TContext db
        {
            get
            {
                if (_db == null) _db = InitialiseDbContext();
                return _db;
            }
        }
        /// <summary>
        /// Create the DbContext, provided to allow inheriting classes to manage how the context is initialised, without allowing them to change the sequence of when such actions ocurr.
        /// </summary>
        protected virtual TContext InitialiseDbContext()
        {
            // Using OWIN by default, you could simplify this to "return new TContext();" if you are not using OWIN to store context per request
            return HttpContext.Current.GetOwinContext().Get<TContext>();
        }
        /// <summary>
        /// Generic access point for specifying the DBSet that this entity collection can be accessed from
        /// </summary>
        /// <returns></returns>
        protected virtual DbSet<TEntity> GetEntitySet()
        {
            return db.Set<TEntity>();
        }
        /// <summary>
        /// Find this item in Db using the default Key lookup lambda
        /// </summary>
        /// <param name="key">Key value to lookup</param>
        /// <param name="query">[Optional] Query to apply this filter to</param>
        /// <returns></returns>
        protected virtual async Task<TEntity> Find(TKey key, IQueryable<TEntity> query = null)
        {
            if (query != null)
                return query.SingleOrDefault(FindByKey(key));
            else
                return GetEntitySet().SingleOrDefault(FindByKey(key));
        }
        /// <summary>
        /// Force inheriting classes to define the Key lookup
        /// </summary>
        /// <example>protected override Expression<Func<TEntity, bool>> FindByKey(TKey key) =>  => x => x.Id == key;</example>
        /// <param name="key">The Key value to lookup</param>
        /// <returns>Linq expression that compares the key field on items in the query</returns>
        protected abstract Expression<Func<TEntity, bool>> FindByKey(TKey key);
        // PUT: odata/DataItems(5)
        /// <summary>
        /// Please use Patch, this action will Overwrite an item in the DB... I pretty much despise this operation but have left it in here in case you find a use for it later.
        /// NOTE: Default UserPolicy will block this action.
        /// </summary>
        /// <param name="key">Identifier of the item to replace</param>
        /// <param name="patch">A deltafied representation of the object that we want to overwrite the DB with</param>
        /// <returns>UpdatedOdataResult</returns>
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromODataUri] TKey key, Delta<TEntity> patch, ODataQueryOptions<TEntity> options)
        {
            Validate(patch.GetInstance());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Delta<TEntity> restrictedObject = null;
            if (!String.IsNullOrWhiteSpace(this.AllowedSelectProperties))
            {
                var updateableProperties = AllowedSelectProperties.Split(',').Select(x => x.Trim());
                /*****************************************************************
                    * Example that prevents patch when invalid fields are presented *
                    * Comment this block to passively allow the operation and skip  *
                    * over the invalid fields                                       *
                    * ***************************************************************/
                if (patch.GetChangedPropertyNames().Any(x => updateableProperties.Contains(x, StringComparer.OrdinalIgnoreCase)))
                    return BadRequest("Can only PUT an object with the following fields: " + this.AllowedSelectProperties);
                /*****************************************************************
                    * Passive example, re-create the delta and skip invalid fields  *
                    * ***************************************************************/
                restrictedObject = new Delta<TEntity>();
                foreach (var field in updateableProperties)
                {
                    if (restrictedObject.TryGetPropertyValue(field, out object value))
                        restrictedObject.TrySetPropertyValue(field, value);
                }
            }
            var itemQuery = GetEntitySet().Where(FindByKey(key));
            var item = itemQuery.FirstOrDefault();
            if (item == null)
                return NotFound();
            if (restrictedObject != null)
                restrictedObject.Patch(item); // yep, revert to patch
            else
                patch.Put(item);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(key))
                    return NotFound();
                else
                    throw;
            }
            return Updated(item);
        }
        // PATCH: odata/DataItems(5)
        /// <summary>
        /// Update an existing item with a deltafied or partial declared JSON object
        /// </summary>
        /// <param name="key">The ID of the item that we want to update</param>
        /// <param name="patch">The deltafied or partial representation of the fields that we want to update</param>
        /// <returns>UpdatedOdataResult</returns>
        [AcceptVerbs("PATCH", "MERGE")]
        public virtual async Task<IHttpActionResult> Patch([FromODataUri] TKey key, Delta<TEntity> patch, ODataQueryOptions<TEntity> options)
        {
            Validate(patch.GetInstance());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!String.IsNullOrWhiteSpace(this.AllowedSelectProperties))
            {
                var updateableProperties = AllowedSelectProperties.Split(',').Select(x => x.Trim());
                /*****************************************************************
                    * Example that prevents patch when invalid fields are presented *
                    * Comment this block to passively allow the operation and skip  *
                    * over the invalid fields                                       *
                    * ***************************************************************/
                if (patch.GetChangedPropertyNames().Any(x => updateableProperties.Contains(x, StringComparer.OrdinalIgnoreCase)))
                    return BadRequest("Can only Patch the following fields: " + this.AllowedSelectProperties);
                /*****************************************************************
                    * Passive example, re-create the delta and skip invalid fields  *
                    * ***************************************************************/
                var delta = new Delta<TEntity>();
                foreach (var field in updateableProperties)
                {
                    if (delta.TryGetPropertyValue(field, out object value))
                        delta.TrySetPropertyValue(field, value);
                }
                patch = delta;
            }
            var itemQuery = GetEntitySet().Where(FindByKey(key));
            var item = itemQuery.FirstOrDefault();
            if (item == null)
                return NotFound();
            patch.Patch(item);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(key))
                    return NotFound();
                else
                    throw;
            }
            return Updated(item);
        }
        /// <summary>
        /// Inserts a new item into this collection
        /// </summary>
        /// <param name="item">The item to insert</param>
        /// <returns>CreatedODataResult</returns>
        [HttpPost]
        public virtual async Task<IHttpActionResult> Post(TEntity item)
        {
            // If you are validating model state, then the POST will still need to include the properties that we don't want to allow
            // By convention lets consider that the value of the default fields must be equal to the default value for that type.
            // You may need to remove this standard validation if this.AllowedSelectProperties has a value
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!String.IsNullOrWhiteSpace(this.AllowedSelectProperties))
            {
                var updateableProperties = AllowedSelectProperties.Split(',').Select(x => x.Trim());
                /*****************************************************************
                    * Example that prevents patch when invalid fields are presented *
                    * Comment this block to passively allow the operation and skip  *
                    * over the invalid fields                                       *
                    * ***************************************************************/
                // I hate to use reflection here, instead of reflection I would use scripts or otherwise inject this logic
                var props = typeof(TEntity).GetProperties();
                foreach(var prop in props)
                {
                    if (!updateableProperties.Contains(prop.Name, StringComparer.OrdinalIgnoreCase))
                    {
                        var value = prop.GetValue(item);
                        bool isNull = false;
                        if (prop.PropertyType.IsValueType)
                            isNull = value == Activator.CreateInstance(prop.PropertyType);
                        else
                            isNull = value == null; 
                        if(isNull) return BadRequest("Can only PUT an object with the following fields: " + this.AllowedSelectProperties);
                    }
                }
                /***********************************************************************
                    * Passive example, create a new object with only the valid fields set *
                    * *********************************************************************/
                var sanitized = Activator.CreateInstance<TEntity>();
                foreach (var field in updateableProperties)
                {
                    var prop = props.First(x => x.Name.Equals(field, StringComparison.OrdinalIgnoreCase));
                    prop.SetValue(sanitized, prop.GetValue(item));
                }
                item = sanitized;
            }
            GetEntitySet().Add(item);
            await db.SaveChangesAsync();
            return Created(item);
        }
        /// <summary>
        /// Overwritable query to check if an item exists, provided to assist mainly with mocking
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual bool ItemExists(TKey key)
        {
            return GetEntitySet().Count(FindByKey(key)) > 0;
        }
    }
