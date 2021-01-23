    DateTime possibleDateTime;
    if (!DateTime.TryParse(context.Request.QueryString["solutionDate"].ToString(), out possibleDateTime))
    {
        //handle the situation where the parse fails
    }
    //if you get here you know there's a valid datetime in possibleDateTime
