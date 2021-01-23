    .WithMemberTypeFormatter((tsProperty, memberTypeName) => {
        var asCollection = tsProperty.PropertyType as TypeLite.TsModels.TsCollection;
        var isCollection = asCollection != null;
    
        if(tsProperty.GenericArguments.Count == 1 && 
           tsProperty.GenericArguments[0] is TypeLite.TsModels.TsClass && 
           ((TypeLite.TsModels.TsClass)tsProperty.GenericArguments[0]).Name =="T") {
               memberTypeName = "any";
        }
        
        return memberTypeName + (isCollection ? string.Concat(Enumerable.Repeat("[]", asCollection.Dimension)) : "");
    })
