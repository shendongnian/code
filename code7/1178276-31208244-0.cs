    var navigationProperties = objectContext.MetadataWorkspace
                            .GetItems<EntityType>(DataSpace.OSpace)
                            .Single(p => p.FullName == typeof(User).FullName)
                            .NavigationProperties;
        
    var one = navigationProperties.Where(navigationProperty => navigationProperty.FromEndMember.RelationshipMultiplicity == RelationshipMultiplicity.One).ToList();
    var many = navigationProperties.Where(navigationProperty => navigationProperty.FromEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many).ToList();
