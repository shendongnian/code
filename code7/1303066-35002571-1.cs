    public IEnumerable<string> GetFKPropertyNames<TEntity>() where TEntity:class
    {
            using (var context = new YourContext())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<TEntity> set = objectContext.CreateObjectSet<TEntity>();
                var Fks = set.EntitySet.ElementType.NavigationProperties.SelectMany(n=>n.GetDependentProperties());
                return Fks.Select(fk => fk.Name);
            }
     }
