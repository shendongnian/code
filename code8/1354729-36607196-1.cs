    public static String strFormattedDate()
    {
        const String sstrDateFormat = "yyyyMM''MMM";
        DateTime dtmLocalDate = DateTime.Now;
        
        return dtmLocalDate.ToString(sstrDateFormat);
    } 
