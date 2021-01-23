    // System.RuntimeType
    [SecurityCritical]
    private object TryChangeType(object value, Binder binder, CultureInfo culture, bool needsSpecialCast)
    {
        ...
        if (this.IsInstanceOfType(value))
        {
          return value;
        }
        ...
          if (RuntimeType.CanValueSpecialCast(valueType, this))
          {
        ...
      }
      throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Environment.GetResourceString("Arg_ObjObjEx"), value.GetType(), this));
    }
