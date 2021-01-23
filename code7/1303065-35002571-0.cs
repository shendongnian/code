    public IEnumerable<string> GetFKPropertyNames<TEntity>()
    {
            using (var context = new YourContext())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<policies_Locations> set = objectContext.CreateObjectSet<policies_Locations>();
                var Fks = set.EntitySet.ElementType.NavigationProperties.SelectMany(n=>n.GetDependentProperties());
                return Fks.Select(fk => fk.Name);
            }
     }
