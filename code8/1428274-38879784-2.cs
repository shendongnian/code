    DateTime date;
    
    bool success = DateTime.TryParseExact(textBoxDate.Text, "dd/MM/yyyy", 
                                          CultureInfo.CurrentCulture, 
                                          DateTimeStyles.AssumeLocal, out date);
    int day;
    if(success)
    {
        day = date.Day; // 1
        // or string stringDay = date.ToString("dd"); to get 01
    }
    else
    {
        // handle error
    }
