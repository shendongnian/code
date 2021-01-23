    try
    {
      GetAutoCAD();
    }
    catch (COMException cx)
    {
        try
        {
            StartAutoCad();
        }
        catch(Exception ex)
        {
          Log.Error(ex);
          throw;
        }
    }
    void GetAutoCAD()
    {
        // try to Get an instance
        _application = Marshal.GetActiveObject(_autocadClassId);
    }
    
    void StartAutoCad()
    {
        var t = Type.GetTypeFromProgID(_autocadClassId, true);
        var obj = Activator.CreateInstance(t, true);
        _application = obj;
    }
