    if(Page.IsPostBack){
       if( String.IsNullOrWhiteSpace(datestextbox.Text)==false)  //textbox in which dates as stored as comma separated
    {
    string[] datesToShow = datestextbox.Text.Split(',');
    foreach (string date in datesToShow)
    {
      yourCalendar.SelectedDates.Add(new DateTime (date )); 
    }
    }
    }
