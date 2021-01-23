     public static void Main()
     {
      string[] dateValues = { "30-12-2011", "12-30-2011", 
                              "30-12-11", "12-30-11" };
      string pattern = "MM-dd-yy";
      DateTime parsedDate;
      foreach (var dateValue in dateValues) {
         if (DateTime.TryParseExact(dateValue, pattern, null, 
                                   DateTimeStyles.None, out parsedDate))
            Console.WriteLine("Converted '{0}' to {1:d}.", 
                              dateValue, parsedDate);
         else
            Console.WriteLine("Unable to convert '{0}' to a date and time.", 
                              dateValue);
      }
    }
