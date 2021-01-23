    public string Name {
      get {
        return name;
      }
      set {
        if (null == value)
          throw new AgrumentNullException("value");
        else if (String.Equals(value, ""))
          throw new AgrumentException("Empty values are not allowed.", "value");
      
        name = value; 
      }
    }
