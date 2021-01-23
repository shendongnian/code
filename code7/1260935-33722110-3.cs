	string FormatMonths(MyClass myObject)
	{
		return FormatMonths(
			myObject.AvailableJan,
			myObject.AvailableFeb,
			myObject.AvailableMar,
			myObject.AvailableApr,
			myObject.AvailableMay,
			myObject.AvailableJun,
			myObject.AvailableJul,
			myObject.AvailableAug,
			myObject.AvailableSep,
			myObject.AvailableOct,
			myObject.AvailableNov,
			myObject.AvailableDec);
	}
    private static string[] months = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    
    string FormatMonthRange(int startMonth, int endMonth, StringBuild sb)
    {
        if (startMonth == 0 && endMonth == 11)
            sb.Append("Year round");
        else if (endMonth == 11 && sb[0] == 'J' && sb[1] == 'a')
        {
            // this deals with wrap around from December to January:
            if (sb.Length > 3 && sb[4] == '-')
                sb.Remove(0, 4);
            sb.Insert(0, months[startMonth] + "-");
        }
        else
        {
            if (sb.Length > 0)
                sb.Append(", ");
            sb.Append(months[startMonth]);
            if (startMonth != endMonth)
                sb.Append("-").Append(months[endMonth]);
        }
    }
    
    string FormatMonths(bool[] monthBools)
    {
        var sb = new StringBuilder();
        int rangeStart = -1;
        for (int i = 0; i < monthBools.Length; i++)
        {
            if (monthBools[i])
            {
                if (rangeStart < 0)
                    rangeStart = i;
            }
            else
            {
                if (rangeStart >= 0)
                {
                    FormatMonthRange(rangeStart, i - 1, sb);
                }
                rangeStart = -1;
            }
        }
        if (rangeStart >= 0)
            FormatMonthRange(rangeStart, monthBools.Length - 1);
        if (sb.Length == 3)
            sb.Append(" only");
        return sb.ToString();
    }
