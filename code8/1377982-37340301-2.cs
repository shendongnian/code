    foreach (RecordRef baseRef in baseRefList)
    {
      var name = baseRef.name;
      //Skip Deprecated countries
      if (name.EndsWith("(Deprecated)")) continue;
      //Use the name to try to find and enumkey match and only add a country if found.
      var enumMatcher = $"_{Regex.Replace(name, @"\W", "").ToLower()}";
      
      //Compares Ignoring Case and Diacritic characters
      var enumMatch = CountryEnumKeys.FirstOrDefault(e => string.Compare(e, enumMatcher, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0);
      
      //Then try by Enum starts with Name but only one.
      if (enumMatch == null)
      {
        var matches = CountryEnumKeys.Where(e => e.ToLower().StartsWith(enumMatcher));
        if (matches.Count() == 1)
        {
          Debug.Write($"- Country Match Hack 1 : ");
          enumMatch = matches.First();
        }
      }
      //Then try by Name starts with Enum but only one.
      if (enumMatch == null)
      {
        var matches = CountryEnumKeys.Where(e => enumMatcher.StartsWith(e.ToLower()));
        if (matches.Count() == 1)
        {
          Debug.Write($"- Country Match Hack 2 : ");
          enumMatch = matches.First();
        }
      }
      //Finally try by first half Enum and Name match but again only one.
      if (enumMatch == null)
      {
        var matches = CountryEnumKeys.Where(e => e.ToLower().StartsWith(enumMatcher.Substring(0, (enumMatcher.Length/2))));
        if (matches.Count() == 1)
        {
          Debug.Write($"- Country Match Hack 3 : ");
          enumMatch = matches.First();
        }
      }
      if (enumMatch != null)
      {
        var enumIndex = Array.IndexOf(CountryEnumKeys, enumMatch);
        if (enumIndex >= 0)
        {
          var country = (Country) enumIndex;
          var nsCountry = new NetSuiteCountry
          {
            Name = baseRef.name,
            Code = baseRef.internalId,
            EnumKey = country.ToString(),
            Country = country
          };
          Debug.WriteLine($"[{nsCountry.Name}] as [{nsCountry.EnumKey}]");
          countries.Add(nsCountry);
        }
      }
      else
      {
        Debug.WriteLine($"Could not find Country match for: [{name}] as [{enumMatcher}]");
      }
    }
