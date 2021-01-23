    public static class CountryHTMLHelpers
     {
          //Initialize your dictionary here
          public static Dictionary<string, string> CountryDictionary;          
          public static IHtmlString ISOToCountry(this HtmlHelper helper, string iso)
          {
              string countryName = CountryDictionary[iso];
              return new HtmlString(countryName);
          }
          public static IHtmlString CountryToISO(this HtmlHelper helper, string country)
          {
              string iso = CountryDictionary.FirstOrDefault(x => x.Value == country).Key;
              return new HtmlString(iso);
          }
    }
