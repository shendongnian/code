      // Just Russia given as ISO 2 letters country code
      String CountryCode = "RU";
    
      var days = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
        .Where(item => item.LCID != 4096) // Cultures without region
        .Where(item => String.Equals(new RegionInfo(item.LCID).Name, 
                                     CountryCode,
                                     StringComparison.OrdinalIgnoreCase))
        .Select(item => item.DateTimeFormat.FirstDayOfWeek)
        .Distinct()
        .ToArray();
    
      if (days.Length <= 0)
        Console.Write("No such regions found, use default (Sunday?)");
      else if (days.Length == 1)
        Console.Write(days[0]); // <- this will return "Monday"
      else
        Console.Write("Too many variants: " + String.Join(", ", days)); 
