    #if UNITY_METRO
    var pia = T.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.GetProperty);
    #else
    var pia = T.GetType().GetProperties(...);
    #endif
