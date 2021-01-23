    private List<String> GetProperties ( Type Model )
    {
        var props = new List<MemberInfo> ( Model.GetFields ( BindingFlags.Public | BindingFlags.Instance ) );
        props.AddRange ( Model.GetFields ( BindingFlags.NonPublic | BindingFlags.Instance ) );
        props.AddRange ( Model.GetProperties ( BindingFlags.Public | BindingFlags.Instance ) );
        props.AddRange ( Model.GetProperties ( BindingFlags.NonPublic | BindingFlags.Instance ) );
    
        var names = new List<String> ( );
        props.ForEach ( prop => names.Add ( prop.Name ) );
    
        return names;
    }
