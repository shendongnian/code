    public static CultureInfo GetCultureFromTwoLetterCountryCode(string twoLetterISOCountryCode)
    {
        try
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures 
                                               & ~CultureTypes.NeutralCultures)
                      .Where(m => m.Name.EndsWith("-"+twoLetterISOCountryCode))
                      .FirstOrDefault();
         }
         catch
         {
             return null;
         }
    }
