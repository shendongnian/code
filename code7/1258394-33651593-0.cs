    [DebuggerStepThrough]
    public bool CanChangeType(this object instance, Type targetType)
    {
      try
      {
        Convert.ChangeType(val, targetType);
        return true;
      }
      catch
      {
        return false;
      }
    }
