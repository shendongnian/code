    protected void AssignMetaData(IMetaDataHolder metaDataHolder){
        var now = DateTime.UtcNow; //or whatever
        var user = Session.User; //or whatever
        metaDataHolder.CreatedBy = user;
        metaDataHolder.CreatedDate = now;
        metaDataHolder.ModifiedBy = user;
        metaDataHolder.ModifiedDate = now; 
    }
