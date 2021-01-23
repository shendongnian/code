    public String Name
    {
        get
        {  switch(Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant())
           {
               case "DE":
                   return dto.Name_De;
               case "FR":
                   return dto.Name_Fr;
               // ...
               default :
                   return String.Empty;
            } 
        }
    }
