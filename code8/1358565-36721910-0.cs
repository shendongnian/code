    private void CoreSomeDbAction(SomeDbContextObject backendContext) {
      //TODO: Some actions using the context
    }
    
    private void SomeDbAction(SomeDbContextObject backendContext = null) {
      if (null == backendContext) {
        // created context should be disposed
        using (SomeDbContextObject context = new SomeDbContextObject(...)) {
          CoreSomeDbAction(context); 
        }
      }
      else 
        CoreSomeDbAction(backendContext); // passed context should be prevent intact
    }
