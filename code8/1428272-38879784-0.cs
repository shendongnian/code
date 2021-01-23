    DateTime date;
    
    bool success = DateTime.TryParseExact(textBoxDate.Text, "dd/MM/yyyy", 
                                          CultureInfo.CurrentCulture, 
                                          DateTimeStyles.AssumeLocal, out date);
    int day;
    if(success)
    {
        day = date.Day;
    }
    else
    {
        // handle error
    }
