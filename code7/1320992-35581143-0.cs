    string[] formats= {"dd/mm/yy","dd/mm/yyyy","dd MMM YYYY","dd-mm-yyyy","dd.mm.yyyy","dd.m.yy","d.m.y"};
          string[] dateStrings = {"5.4.1","1.1.4","12.1.13"}; 
          DateTime dateValue;
          foreach (string dateString in dateStrings)
          {
             if (DateTime.TryParseExact(dateString, formats, 
                                        new System.Globalization.CultureInfo("en-US"), 
                                        System.Globalization.DateTimeStyles.None, 
                                        out dateValue))
                Console.WriteLine("Converted '{0}' to {1}.", dateString, dateValue);
             else
                Console.WriteLine("Unable to convert '{0}' to a date.", dateString);
                }
