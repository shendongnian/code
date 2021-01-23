        myObject = new MyObject()
        // More code here...
    
        myObject.Dispose();
    That will be ok if you are sure that between the creation of your instance and the calling to the *Dispose* method there is no exception in your code, which could cause the call to *Dispose* to be missed. Of course you can always use a *finally* block:
        try {
          MyObject myObject = new MyObject()
          (...)
    
        }
        catch (Exception) {
          // manage exception
        }
        finally {
          if (myObject != null)
            myObject.Dispose();
        }
