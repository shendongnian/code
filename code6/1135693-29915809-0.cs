    ModifyExistingEntity( Product entity, ProductModel item )
    {
        bool isModified = false;
    
        isModified |= ( entity.Title != item.Title )
            && retTrue( entity.Title =  item.Title );
        isModified |= ( entity.ServerId != item.Id )
            && retTrue( entity.ServerId =  item.Id );
    
        return isModified;
    }
    retTrue( object x ) { return true; } // Helper method
