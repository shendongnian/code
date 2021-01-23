    Type ObjectType = ObjectYouWantMetaDataTypeFrom.GetType();
    object ObjectMetaData = ObjectType.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
    MetadataTypeAttribute MetaData = ObjectMetaData as MetadataTypeAttribute;
    if (MetaData == null)
    { throw new NullReferenceException(); }
    Type metadataClassType = MetaData.MetadataClassType;
