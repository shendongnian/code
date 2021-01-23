    private bool IsSelectionValid()
    {
        DateTime fromTime;
        DateTime toTime;
        if(!DateTime.TryParse(ddlTimeFrom.SelectedValue, out fromTime) ||
           !DateTime.TryParse(ddlTimeTo.SelectedValue, out toTime))
        {
            return false;
        }
    
        return fromTime < toTime;
    }
