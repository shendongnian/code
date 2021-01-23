    public static class DbContextExtensions
    {
        public static void Visit(this DbContext context, object entity, Action<object> action)
        {
            Action<object, DbContext, HashSet<object>, Action<object>> visitFunction = null; // Initialize first to enable recursive call.
            visitFunction = (ent, contxt, hashset, act) =>
              {
                  if (ent != null && !hashset.Contains(ent))
                  {
                      hashset.Add(ent);
                      var entry = contxt.Entry(ent);
                      if (entry != null)
                      {
                          act(ent);
                          foreach (var np in contxt.GetNavigationProperies(ent.GetType()))
                          {
                              if (np.ToEndMember.RelationshipMultiplicity < RelationshipMultiplicity.Many)
                              {
                                  var reference = entry.Reference(np.Name);
                                  if (reference.IsLoaded)
                                  {
                                      visitFunction(reference.CurrentValue, contxt, hashset, action);
                                  }
                              }
                              else
                              {
                                  var collection = entry.Collection(np.Name);
                                  if (collection.IsLoaded)
                                  {
                                      var sequence = collection.CurrentValue as IEnumerable;
                                      if (sequence != null)
                                      {
                                          foreach (var child in sequence)
                                          {
                                              visitFunction(child, contxt, hashset, action);
                                          }
                                      }
                                  }
                              }
                          }
                      }
                  }
              };
            visitFunction(entity, context, new HashSet<object>(), action);
        }
    
        // Get navigation properties of an entity type.
        public static IEnumerable<NavigationProperty> GetNavigationProperies(this DbContext context, Type type)
        {
            var oc = ((IObjectContextAdapter)context).ObjectContext;
            var entityType = oc.MetadataWorkspace.GetItems(DataSpace.OSpace).OfType<EntityType>()
                               .FirstOrDefault(et => et.Name == type.Name || et.Name == type.BaseType.Name); // BaseType: for proxies
            return entityType != null
                ? entityType.NavigationProperties
                : Enumerable.Empty<NavigationProperty>();
        }
    }
