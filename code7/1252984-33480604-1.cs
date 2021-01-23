     var directoryEntry = new DirectoryEntry(APPLICATION_POOL_URL, USERNAME,   PASSWORD);
  
           // call to stop the Application Pool
         directoryEntry.Invoke("Stop", null);
  
          // call to start the Application Pool
              directoryEntry.Invoke("Start", null);
  
         // call to recycle the Application Pool
            directoryEntry.Invoke("Recycle", null);
