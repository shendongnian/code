      try
      {
           BuiltInDocumentProperties = new Dictionary<string, string>();
           var builtinProps = Doc.BuiltInDocumentProperties; // don't strong cast this or you will get null
           SetBuiltInProperty(builtinProps, "Title");
           SetBuiltInProperty(builtinProps, "Keywords");
      }
      catch (Exception e)
      {
           // Ignorer l'erreur
           Log.Warn("Erreur inattendue à la lecture des propriétés internes du document", e);
      }
      IDictionary<string, string> BuiltInDocumentProperties { get; set; }
      internal void SetBuiltInProperty(dynamic builtInProps, string property)
      {
          if (builtInProps != null)
          {
              try
              {
                  var prop = builtInProps[property];
                  if (prop != null)
                  {
                      string str = prop.Value.ToString();
                      BuiltInDocumentProperties[property] = str;
                  }
              }
              catch (COMException)
              {
              }
          }
     }
