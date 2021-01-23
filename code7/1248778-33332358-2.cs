    private int convertDateTime(DateTime input)
    {
        DateTime start = new DateTime(1900, 1, 1);
        return (int)(input - start).TotalDays + 2; //This is some calibration with the above mentioned Office article
    }
