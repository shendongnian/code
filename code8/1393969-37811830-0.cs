      public void Update() {
        try {
          ...
          // you can return  
          if (someCondition)
            return;
          ...
          // throw exceptions
          if (someOtherCondition)
            throw... 
          ...
        }
        finally {
          // However, finally will be called rain or shine
        }
      } 
 
    
