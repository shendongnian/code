    var allEdmx = typeMapper.GetItemsToGenerate<EntityType>(itemCollection);
    // entity is just an entry in allEdmx    
        var association = ((AssociationType)entity.RelationshipType);
        if (association.ReferentialConstraints.Count > 0)
        {
            var fromProperties = association.ReferentialConstraints[0].FromProperties;
            var toProperties = association.ReferentialConstraints[0].ToProperties;
        #>
        //query = query.Where(p => p.<#=toProperties[0].Name#> == idToFind);
        <#
        }
        else if (association.RelationshipEndMembers.Count > 0)
        {
       
    var getPriamryKey = allEdmx.FirstOrDefault(d => d.Name == entity.FromEndMember.Name);
                var simpleProperties = typeMapper.GetSimpleProperties(getPriamryKey);
    			if (simpleProperties.Any())
    			{
    				var primaryKeys = typeMapper.GetPrimaryKeys(ef, simpleProperties);
    
    				if (primaryKeys.Any() && primaryKeys.Count() == 1)
    				{
    #>
    		//query = query.Where(p => p.<#=entity.Name#>.<#=codeStringGenerator.JustGetName(primaryKeys.FirstOrDefault())#> == idToFind);
    		<#
    				}
    }
    // Added this to the codeStringGenerator class
        public string JustGetName(EdmProperty edmProperty)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}",
                _code.Escape(edmProperty)
    			);
    }
