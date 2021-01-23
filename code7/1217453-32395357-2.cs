    public enum OptionValue {
      Unavailable,
      Enabled,
      Disabled
      // Obsolete,    // can be found in earlier versions only
      // NotSupported // say, technically could be enabled but it will do nothing
      // Proposed // in future versions 
    }
    
    // if you add some values into OptionValue enum, 
    // you have to update this class only, not the whole application
    public static class OptionValueExtensions() {
      // If option is available and enabled 
      public static Boolean IsOn(this OptionValue value) { 
        return value == OptionValue.Enabled;
      }
      // If option is either disabled or unavailable
      public static Boolean IsOff(this OptionValue value) { 
        return (value == OptionValue.Disabled) || (value == OptionValue.Unavailable);
      }
    }
    
    ...
    
    OptionValue myOption = ...
    
    // it's easy with enum (and extension class)
    // if myOption is in fact (by whatever reason) is off then...
    if (myOption.IsOff()) {...}
