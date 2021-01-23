    foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
    {
         try
         {
              var c = new CultureInfo(culture.TwoLetterISOLanguageName);
         }
         catch (Exception)
         {
              Console.WriteLine(culture.TwoLetterISOLanguageName); // Only prints "iv"
         }
    }
