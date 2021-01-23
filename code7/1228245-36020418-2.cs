    public static string DateConversion(string inputDate, string inputDateFormat,string destinationDateFormat)
    {
        string strReturn = string.Empty;           
        var formattedDate = DateTime.ParseExact(inputDate, inputDateFormat, System.Globalization.CultureInfo.InvariantCulture);
        strReturn = formattedDate.ToString(destinationDateFormat);              
        return strReturn;
    }
