    FileStream fs;
    try {
    
        fs = File.OpenRead(sourceFile); 
    }
    catch(..) {
    }
    catch(..) {
    }
    catch(..) {
    }
    finally {
    
      if(fs !=null) {
          fs.Close();
          fs.Dispose();
      }
    }
