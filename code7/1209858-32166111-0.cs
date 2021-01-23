    IFunctionality {
      DoIt();
    }
    
    class BasicFunctionality: IFunctionality {
      public DoIt() {
        // Default behaviour goes here
      }
    }
    
    class PluginFunctionality: IFunctionality {
      public DoIt() {
        // Alternative functionality.
      }
    }
