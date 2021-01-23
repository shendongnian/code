       DateTime CreatdDate = DateTime.ParseExact(tbx_Created.Text, 
         new String[] {
           "MM/dd/yyyy hh:mm:ss tt", // your initial pattern, recommended way
           "d-M-yyyy"},              // actual input, tolerated way
         System.Globalization.CultureInfo.InvariantCulture,
         DateTimeStyles.AssumeLocal); 
