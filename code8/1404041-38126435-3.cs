    private string ExtractWeekDayNames(IReceipt receipt) 
    {
        string retVal = "";
        Dictionary<string, bool> WeekDays = 
            new Dictionary<string, bool>() {
                                            { "Sun", receipt.Sunday },
                                            { "Mon", receipt.Monday },
                                            { "Tue", receipt.Tuesday },
                                            { "Wed", receipt.Wednesday },
                                            { "Thu", receipt.Thursday },
                                            { "Fri", receipt.Friday },
                                            { "Sat", receipt.Saturday }
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
