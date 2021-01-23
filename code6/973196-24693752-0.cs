    public static void CopyObject<T>(T sourceObject, ref T destObject)
    {            
        if (sourceObject == null || destObject == null)
            return;
        //  Get the type of each object
        Type sourceType = sourceObject.GetType();
        Type targetType = destObject.GetType();
        //  Loop through the source properties
        foreach (PropertyInfo sourceProp in sourceType.GetProperties())
        {
            //  Get the matching property in the destination object
            PropertyInfo destProp = targetType.GetProperty(sourceProp.Name);
            //  If there is none, skip
            if (destProp == null)
                continue;
            //  Set the value in the destination
            object value = sourceProp.GetValue(sourceObject, null);
            destProp.SetValue(destObject, value, null);
        }
    }
