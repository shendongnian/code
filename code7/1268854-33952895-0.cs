    internal static bool TryParse(String s, DateTimeFormatInfo dtfi, DateTimeStyles styles, out DateTime result) {
        result = DateTime.MinValue;
        DateTimeResult resultData = new DateTimeResult();       // The buffer to store the parsing result.
        resultData.Init();
        if (TryParse(s, dtfi, styles, ref resultData)) {
            result = resultData.parsedDate;
            return true;
        }
        return false;
    }
