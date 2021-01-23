    public class Notification : Common
    {
      public Notification()
      {
        this.substitutionStringsBackingStore =
           new Dictionary<string,string>( StringComparer.OrdinalIgnoreCase )
           ; 
      }
      
      [JsonProperty("substitutionStrings")]
      public Dictionary<string, string> SubstitutionStrings
      {
        get { return substitutionStringsBackingStore         ; }
        set {        substitutionStringsBackingStore = value ; }
      }
      private Dictionary<string,string> substitutionStringsBackingStore ;
    }
