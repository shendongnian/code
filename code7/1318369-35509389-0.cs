    protected void UpdatePanelDateChanged_Load(object sender, EventArgs e)
    {
        if (Request["__EVENTTARGET"] == UpdatePanelDateChanged.ClientID)
        {
            //Trigger Event
            OnDateChanged(new DateChangedEventArgs(DateTime.Parse(dates[0]), DateTime.Parse(dates[1])));
        }
    }
    
