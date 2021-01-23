    public object SafeConvertChangeType(object value,Type targetType)
          {
          object result ;
          try {
               result = Convert.ChangeType(value, targetType);
          }
          catch (FormatException)
          catch (InvalidCastException) {
               result = null;
          }
    return result;
    }
