    public static void ConfigureColumn<T>(GridColumnBase<T> column) where T : class
    {
       CachedDataAnnotationsModelMetadata metadata = ((dynamic)column).Metadata;
       object attributeValue = null;
       if (metadata.AdditionalValues.TryGetValue(GridColumnAttribute.Key, out attributeValue))
       {
          var attribute = (GridColumnAttribute)attributeValue;
          column.Width = attribute.Width;
       }
    }
