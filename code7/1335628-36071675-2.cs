	public abstract class DynamicNavigationODataController<TEntity> : ODataController
	{
		public IHttpActionResult GetRelatedEntityCollection([FromODataUri] int key, string navigationProperty)
		{
			// Data access logic goes here. Retrieve the TEntity having the given 
            // key, and then retrieve the named navigation property.
		}
		public IHttpActionResult GetRelatedSingleEntity([FromODataUri] int key, string navigationProperty)
		{
			// Data access logic goes here. Retrieve the TEntity having the given 
            // key, and then retrieve the named navigation property.
		}
	}
