    DateTime dt = new DateTime();
    bool parseResult = DateTime.TryParseExact(Input.ToString(), "MMMM yyyy", 
                       CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
    if(parseResult)
    {
     Response.Write(dt.ToString("yyyy-MM"));
    }
    else
    {
     //Error message about parse fail perhaps?
    }
