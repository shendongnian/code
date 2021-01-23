    if (pageParameters.PageSize * pageParameters.CurrentPageNumber > eventsResults.Results.Count()
    {
        var queryResultPage = eventsResults.Results.Reverse().Take(pageParameters.PageSize).Reverse();
    }
    else
    {
        // do the paging same way you did before
    }
