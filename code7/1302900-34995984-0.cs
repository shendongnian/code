    private void DoStuff<T>(StagedEntity<T> stagedEntity) // note the arg type
    {
    
      var properties = stagedEntity.EntityType.GetProperties().ToList();
    
      foreach ( var item in stagedEntity.StagedItems ) {
        foreach ( var property in properties ) {
          // Do something with
          // property.GetValue( item, null );
        }
      }
    }
