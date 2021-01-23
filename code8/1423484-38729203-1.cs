    string dateString;
          CultureInfo culture;
          DateTimeStyles styles;
          DateTime dateResult;    
    // Parse a date and time with no styles.
          dateString = "03/01/2009 10:00 AM";
          culture = CultureInfo.CreateSpecificCulture("en-US");
          styles = DateTimeStyles.None;
          if (DateTime.TryParse(dateString, culture, styles, out dateResult))
             Console.WriteLine("{0} converted to {1} {2}.", 
                               dateString, dateResult, dateResult.Kind);
          else
             Console.WriteLine("Unable to convert {0} to a date and time.", 
                               dateString);
