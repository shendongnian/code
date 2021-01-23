    DateTime textCitDateTime;
    if(DateTime.TryParse(txtCIT.Text, out textCitDateTime))
    {
        DateTime LDOM = StringExtensions.LastDayOfMonth(textCitValue);
        // your logic here
    }
    else
    {
        // handle invalid textbox date here
    }
