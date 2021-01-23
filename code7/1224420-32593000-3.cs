    public class StringDateComparer : IComparer<string>
    {
    
        public int Compare(string date1, string date2)
        {
            DateTime parsedDate1;
            DateTime.TryParseExact(date1, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate1);
               
    
            DateTime parsedDate2;
            DateTime.TryParseExact(date2, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate2);
                
    
    
            if (parsedDate1 < parsedDate2)
                return -1;
            if (parsedDate1 > parsedDate2)
                return 1;
    
    
            return 0;
        }
    }
