    public static class DbContextExtensions
    {
        private static readonly ConcurrentDictionary< EntityType, ReadOnlyDictionary< string, NavigationProperty>> s_navPropMappings = new ConcurrentDictionary< EntityType, ReadOnlyDictionary< string, NavigationProperty>>();
    
        public static void DeleteOrphans( this DbContext source )
        {
            var context = ((IObjectContextAdapter)source).ObjectContext;
            foreach (var entry in context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified))
            {
                var entityType = entry.EntitySet.ElementType as EntityType;
                if (entityType == null)
                    continue;
    
                var navPropMap = s_navPropMappings.GetOrAdd(entityType, CreateNavigationPropertyMap);
                var props = entry.GetModifiedProperties().ToArray();
                foreach (var prop in props)
                {
                    NavigationProperty navProp;
                    if (!navPropMap.TryGetValue(prop, out navProp))
                        continue;
    
                    var related = entry.RelationshipManager.GetRelatedEnd(navProp.RelationshipType.FullName, navProp.ToEndMember.Name);
                    var enumerator = related.GetEnumerator();
                    if (enumerator.MoveNext() && enumerator.Current != null)
                        continue;
    
                    entry.Delete();
                    break;
                }
            }
        }
    
        private static ReadOnlyDictionary<string, NavigationProperty> CreateNavigationPropertyMap( EntityType type )
        {
            var result = type.NavigationProperties
                .Where(v => v.FromEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many)
                .Where(v => v.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.One || (v.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.ZeroOrOne && v.FromEndMember.GetEntityType() == v.ToEndMember.GetEntityType()))
                .Select(v => new { NavigationProperty = v, DependentProperties = v.GetDependentProperties().Take(2).ToArray() })
                .Where(v => v.DependentProperties.Length == 1)
                .ToDictionary(v => v.DependentProperties[0].Name, v => v.NavigationProperty);
    
            return new ReadOnlyDictionary<string, NavigationProperty>(result);
        }
    }
