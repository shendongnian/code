    class MyClass
    {
      StorageFile m_pickedFile;
    
      async Task GetFile()
      {
        // Setup the picker...
        m_pickedFile = await openPicker.PickSingleFileAsync();
    
        // Show the path to the user...
      }
    
      async Task ProcessFile()
      {
        if (m_pickedFile != null)
        {
          // now use m_pickedFile...
        }
      }
    }
 
  
