    public string ConvertDateCalendar(DateTime DateConv, ECalenderTypes calendar, string DateLangCulture)
    {
        System.Globalization.DateTimeFormatInfo DTFormat;
        DateLangCulture = DateLangCulture.ToLower();
        /// We can't have the hijri date writen in English. We will get a runtime error
    
        if (calendar == ECalenderTypes.Hijri && DateLangCulture.StartsWith("en-"))
        {
            DateLangCulture = "ar-sa";
        }
    
        /// Set the date time format to the given culture
        DTFormat = new System.Globalization.CultureInfo(DateLangCulture, false).DateTimeFormat;
    
        /// Set the calendar property of the date time format to the given calendar
        switch (calendar)
        {
            case ECalenderTypes.Hijri:
                DTFormat.Calendar = new System.Globalization.HijriCalendar();
                break;
    
            case ECalenderTypes.Gregorian:
                DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                break;
    
            default:
                return "";
        }
    
        /// We format the date structure to whatever we want 
        DTFormat.ShortDatePattern = "dd/MM/yyyy";
        return (DateConv.Date.ToString("f", DTFormat));
    }
