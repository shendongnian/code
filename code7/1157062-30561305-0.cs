    public static void MyMethod( Func<Dictionary<dynamic, dynamic>> tableArgCreator,
     /* ... more args ... */ )
    {
        var table = tableArgCreator();
        ...
    }
    MyMethod( table: GetDynamicDictionaryValue, /* ... */ );
 
