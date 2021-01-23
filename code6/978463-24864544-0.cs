    public string CamelCase { get; set; }
    [XmlElement("CamelCASE"), Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string CamelCaseLegacy {
        get { return CamelCase; }
        set { CamelCase = value; }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCamelCaseLegacy() { return false; }
