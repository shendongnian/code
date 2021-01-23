    //TODO: declare value actual type
    SomeType value;
    if (parameter.AuxProperty.TryGetValue("art_nr", out value)) {
      itemnumber = value.ToString();
      ...
    }
    else {
      // No such value 
      itemnumber = "";
      ...
    }
