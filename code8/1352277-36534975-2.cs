      public void RunOps(Action<string> formNotifier)
      {
          string status = "Initialize ops";
          if(formNotifier != null)
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
        
