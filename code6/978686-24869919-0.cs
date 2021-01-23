    public static Boolean IsContained(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
    {
        // convert all DateTime to Int
        Int32 start1_int = start1.Hour * 60 + start1.Minute;
        Int32 end1_int = end1.Hour * 60 + end1.Minute;
        Int32 start2_int = start2.Hour * 60 + start2.Minute;
        Int32 end2_int = end2.Hour * 60 + end2.Minute;
        // add 24H if end is past midnight
        if (end1_int <= start1_int)
        {
            end1_int += 24 * 60;
        }
        if (end2_int <= start2_int)
        {
            end2_int += 24 * 60;
        }
        return (start1_int <= start2_int && end1_int >= end2_int);
    }
