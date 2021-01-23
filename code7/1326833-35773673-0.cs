    public static DataTable ConvertListToDataTable<T>(List<T> list)
    {
        Type listType = typeof(T);
        if(listType == typeof(CameraSetting))
        {
            //...
        }
        else if(listType == typeof(OtherThing))
        {
            //...
        }
        else  // if not everything is allowed
            throw new NotSupportedException(listType.ToString() + " is not supported in ConvertListToDataTable");
    }
