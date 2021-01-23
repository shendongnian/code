    try
    {
      // you may choose to reverse this, by calling getActiveObject first
      // or you can try repeating the getActiveObject after a short delay
      var t = Type.GetTypeFromProgID(_autocadClassId, true);
      // Create a new instance AutoCAD
      _application = Activator.CreateInstance(t, true);      
    }
    catch (COMException ex)
    {
        try
        {
            // Start works every time, but due to the delay it may appear not to
            // check task manager when testing this
            // add a delay here before trying to get what was started
            Thread.Sleep(750); //for example
            _application = Marshal.GetActiveObject(_autocadClassId);
        }
        catch (Exception e2x)
        {
            Log.Error(e2x);
        }
    }
