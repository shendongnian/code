    static void CopyData(object source, object destination)
    {
      Type srcType = source.GetType();
      List<PropertyInfo> destProperties = new List<PropertyInfo>(destination.GetType().GetProperties());
      foreach (PropertyInfo destProperty in destProperties)
      {
        if (destProperty.CanWrite)
        {
          PropertyInfo srcProperty = srcType.GetProperty(destProperty.Name);
          if (srcProperty != null && srcProperty.CanRead)
          {
            destProperty.SetValue(destination, srcProperty.GetValue(source));
          }
        }
      }
    }
