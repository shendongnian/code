    string pattern = @"\d{4}-\d{2}-\d{2} \d{1,2}:\d{1,2}:\d{1,2}";
    string p = "v 0 fl 0x4; value 8 feat 0; sn AC0809099; mn -; tim 2015-10-11 20:50:36 8 Access Points";
    string[] pArray = p.Split(';');
    DateTime dtOutput;
    if (pArray[4] != null) {
        string match = Regex.Match(pArray[4], pattern).Value;
        DateTime.TryParseExact(match, "yyyy-MM-dd HH:mm:ss",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out dtOutput);
    }
    
    // dtOutput will hold the required date
