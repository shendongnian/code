    public class LocalizationService : IStringLocalizer {
    
      public LocalizedString this[string name] {
        return new LocalizedString(name, Properties.Resources.GetString(name));
      }
    //implement the rest of methods of IStringLocalizer 
    
    }
