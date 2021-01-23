    IFunctionalityX {
      DoIt();
    }
    
    class BasicFunctionalityX: IFunctionalityX {
      public DoIt() {
        // Default behaviour goes here
      }
    }
    
    class PluginFunctionalityX: IFunctionalityX {
      public DoIt() {
        // Alternative functionality.
      }
    }
