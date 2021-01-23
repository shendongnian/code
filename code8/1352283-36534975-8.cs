      public void MultipleStepsOperation(Action<string> formNotifier)
      {
          string status = "Initialize ops";
          if(formNotifier != null)
             // Invoke is not required, just for clarity
             // formNotifier(status); // the same as below...
             formNotifier.Invoke(status);
          ....
          status = "Executing step 1";
          if(formNotifier != null)
             formNotifier.Invoke(status);
          status = "Executing step 2";      
          if(formNotifier != null)
             formNotifier.Invoke(status);
          ....
      }
        
