    string messageError = null;
    string convertTodate = "34/";
    string convertToInt = "3.5";
    try
    {
        int newInt = Convert.ToInt32(convertToInt);
    }
    catch(FormatException)
    {
        messageError = "That field must be integer";
    }
    try
    {
        DateTime newDate = Convert.ToDateTime(convertTodate);
    }
    catch(FormatException)
    {
        messageError = "Your date field must be dd/mm/yyy";
    }
    if(string.IsNullOrEmpty(messageError))
    {
        // All Ok
    }
    else
    {
        // Display error contained witin messageError 
    }
