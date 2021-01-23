    private static DateTime DropMilliseconds(DateTime dtm)
    {
        return new DateTime(dtm.Year, dtm.Month, dtm.Day, 
                            dtm.Hour, dtm.Minute, dtm.Second, 
                            dtm.Kind);
    }
