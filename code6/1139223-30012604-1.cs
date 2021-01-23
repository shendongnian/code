    public Dictionary<string, Parameter> m_Settings = new Dictionary<string, Parameter>();
    // NOTE: we're returning the dictionary values here only
    public IEnumerable<Parameter> Settings { get { return m_Settings.Values; } }
    ...
    var p1 = new StringParameter( "Parameter 1", "Value 1" );
    var p2 = new StringParameter( "Parameter 2", "Value 2" );
    var p3 = new StringParameter( "Parameter 3", "Value 3" );
    m_Settings.Add( p1.Key, p1 );
    m_Settings.Add( p2.Key, p2 );
    m_Settings.Add( p3.Key, p3 );
