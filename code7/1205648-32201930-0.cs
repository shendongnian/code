    public Dictionary<string,string> GetForeignKeyProperties<DBType>()
    {
    	EntityType table = GetTableEntityType<DBType>();
    	Dictionary<string, string> foreignKeys = new Dictionary<string, string>();
    
    	foreach (NavigationProperty np in table.NavigationProperties)
    	{
    		var association = (np.ToEndMember.DeclaringType as AssociationType);
    		var constraint = association.ReferentialConstraints.FirstOrDefault();
    
    		
    
    		if (constraint != null && constraint.ToRole.GetEntityType() == table)
    			foreignKeys.Add(np.Name, constraint.ToProperties.First().Name);
    
    		if (constraint != null && constraint.FromRole.GetEntityType() == table)
    			foreignKeys.Add(np.Name, constraint.ToProperties.First().DeclaringType.Name+"."+constraint.ToProperties.First().Name);
    	}
    
    	return foreignKeys;
    }
    
    private EntityType GetTableEntityType<DBType>()
    {
    	return GetTableEntityType(typeof(DBType));
    }
    
    private EntityType GetTableEntityType(Type DBType)
    {
    	ObjectContext objContext = ((IObjectContextAdapter)this).ObjectContext;
    	MetadataWorkspace workspace = objContext.MetadataWorkspace;
    	EntityType table = workspace.GetEdmSpaceType((StructuralType)workspace.GetItem<EntityType>(DBType.FullName, DataSpace.OSpace)) as EntityType;
    	return table;
    }
