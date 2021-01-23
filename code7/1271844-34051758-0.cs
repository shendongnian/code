       private  DateTime  timePoint;
       public string FormatedDateTime
        {
            get
            {
               return timePoint.ToString("MMMM dd, yyyy hh:mm:ss tt", CultureInfo.CurrentCulture);
            }
            set
            {
                timePoint =  Convert.ToDateTime(value);
            }
        }
