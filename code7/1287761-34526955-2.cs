    public static bool WriteLog_Reflection<T>(string fileName, long maxLogSizeMB,
        IEnumerable<T> newObcObject, out string strError)
    {
        // ...
        // This:
        // 
        // string lines = string.Empty;
        // foreach (var item in newObcObject)
        // {
        //     foreach (var prop in item.GetType().GetProperties())
        //     {
        //         lines += prop.GetValue(item, null).ToString() + "; ";
        //     }
        // }
        //
        // could be replaced to this:
    
        var lines = string.Join("; ", newObcObject
            .SelectMany(item => item.GetType().GetProperties(),
                (item, property) => property.GetValue(item, null)));
    
        // ...
    }
