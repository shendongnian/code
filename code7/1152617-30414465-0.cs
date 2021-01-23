    string dateString = "4/23/2015";
    string controlName = "NXG-Alpha";
    string controlSubDirectory = "S";
    string controlPage = "w-In-a-Core-IT-Company";
    // If we have a valid date
    DateTime dateTime = DateTime.MinValue;
    if (DateTime.TryParse(dateString, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out dateTime))
    {
        // Setup Navigation URL
        HyperLink hreflink = (HyperLink)item.FindControl("hreftitle");
        hreflink.NavigateUrl = string.Format("../{0}/{1}/{2}", controlName, controlSubDirectory, controlPage);
    }
    else
    { 
        // Date Error
        // TODO...
    }
