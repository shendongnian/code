    public class MyController : ApiController
    {
        // Add the queryable attribute
        [Queryable]
        IQueryable<stuff> Get() {
            ...
            ...
            return myStuff.AsQueryable();
    }
