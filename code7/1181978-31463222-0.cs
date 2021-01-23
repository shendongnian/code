    var types = typeof (Entity).Assembly.GetTypes().Where(t => !t.IsInterface).OrderBy(x => x, new EntityTypeComparer());
    var mapping = mapper.CompileMappingFor(types);    
    public class EntityTypeComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {           
            if (x == y)
                return 0;
            if (x.IsAssignableFrom(y) || (!x.IsAssignableTo<Entity>() && y.IsAssignableTo<Entity>()))
                return -1;
            if (y.IsAssignableFrom(x) || (!y.IsAssignableTo<Entity>() && x.IsAssignableTo<Entity>()))
                return 1;
            return 0;
        }
    }       
