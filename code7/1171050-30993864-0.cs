    int weekId = 0;
    
    //first try and parse the int from the query string. Note the  ?? will execute the statement 
    //following when the result is null. https://msdn.microsoft.com/en-us/library/ms173224.aspx
    if (!int.TryParse((Request.QueryString["WeekId"] ?? ""), out weekId))
    {
        Response.Write("<h4>Sorry! You didnt select a valid week. Please use Back button of browser and try again!</h4>");
        Response.End();
    }
    
    //next lets check the value of the day of week.. 
    if (((int)DateTime.Now.DayOfWeek) != weekId)
    {
        Response.Write("<h4>Sorry! Today is NOT the week you selected. Please use Back button of browser and try again!</h4>");
        Response.End();
    }
