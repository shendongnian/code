    string timestring = "0 hours 1 minutes";
    string pattern = "H' hours 'm' minutes'";
            
    var dt = new DateTime();
    if (DateTime.TryParseExact(timestring, pattern, CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
    {
        //success
    }
    else
    {
        //wrong input
    }
