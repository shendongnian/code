    public override saveChanges(){
        // gather audit data
        initialize List<Entity> addedEntities, modifiedEntities, deletedEntities
        var changeList = tracker.detectChange();
        foreach(var change in changeList){
            switch(change.state){
                case ADD: add to addedEntities
                case MODIFIED: add to modifiedEntities
            }
        }
          
          
        base.saveChanges();
        performAudit(addedEntities, modifiedEntities, deletedEntities);
    }
    
    function performAudit(...){
      generateXML(...);
      saveToDB(...);
      sendEmail(...);
    }
