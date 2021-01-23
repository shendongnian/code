    var associations = new List<Association>();
    associations.Select(e => 
    {
    	var type = types.Find(t => t.TypeId == e.TypeId);
    	var subType = subTypes.Find(st => st.SubTypeId == e.SubTypeId);
    
    	return new TypeInfo() { TypeId = e.TypeId, TypeName = type.TypeName, SubTypeId = e.SubTypeId, SubTypeName = subType.SubTypeName };
    });
