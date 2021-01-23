    private string ExtractWeekDayNames<T>(T fiscalReceipt) where try : IReceipt
    {
        string retVal = "";
        Dictionary<string, bool> WeekDays = 
            new Dictionary<string, bool>() {
                                            { "Sun", fiscalReceipt.Sunday },
                                            { "Mon", fiscalReceipt.Monday },
                                            { "Tue", fiscalReceipt.Tuesday },
                                            { "Wed", fiscalReceipt.Wednesday },
                                            { "Thu", fiscalReceipt.Thursday },
                                            { "Fri", fiscalReceipt.Friday },
                                            { "Sat", fiscalReceipt.Saturday }
                                            };
        //Find week days
        foreach (var item in WeekDays)
        {
            if (item.Value == true)
                retVal += item.Key + ",";
        }
        if (!string.IsNullOrEmpty(retVal))
            retVal = retVal.Substring(0, retVal.Length - 1);
        return retVal;
    }
