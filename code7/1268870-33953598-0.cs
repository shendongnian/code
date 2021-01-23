    class Monster {
      [Flags]
      private enum Status {
        Updated,
        Called,
        Killed,  
        ... 
      }
    
      private Status status;
    
      void Update() {
        if ((status & Status.Updated) == Status.Updated)
          return;
    
        try {
          ....
        }
        finally {
          status |= Status.Updated;
        } 
      }
    }
