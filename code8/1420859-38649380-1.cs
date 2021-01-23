    public class EntityContext
    {
        public static EntityContext Current
        {
            get { return HttpContext.Current.Items["_EntityContext"] as EntityContext; }
        }
    }
