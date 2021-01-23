    public string Name 
    { 
       get { return name; }
       // sets field value depending on condition
       set { name = !string.IsNullOrEmpty(value) && value.Length < 20 ? value : name; } 
    }
