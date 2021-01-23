    string someDate = "12.30.2015";
    string newDate = "";
    foreach (char c in someDate)
    {
        if (c == '.' || c == '-')
        {
            newDate += '/';
        }
        else
        {
            newDate += c;
        }
    }
 
