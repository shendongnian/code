    private int _version;
    [Required]
    public int Version 
    { 
       get 
       { 
          return _version; 
       }
       set; 
       { 
          _version = value; 
          VersionSchemeCode = String.Format("{0}{1}", Version, Scheme.SchemeCode);
       }
    }
