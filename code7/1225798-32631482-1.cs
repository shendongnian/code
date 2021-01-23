    public string Name {
      get {
        return name;
      }
      set {
        if (String.IsNullOrEmpty(value))
          throw new AgrumentException("Null or empty values are not allowed.", "value");
      
        name = value; 
      }
    }
