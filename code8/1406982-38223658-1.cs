    foreach(var recipientCollection in recipientCollections)
    {
        var secondaryCountryRecipientList = string.Join(",",refinedCountryRecipients);
        var emailApiParams = new SendEmailParametersModel(CountrySubscriberApplicationId, queueItem.SitecoreId, queueItem.Version, queueItem.Language, countryFeedItem.Subject,countryFeedItem.Html, countryFeedItem.From, _recipientsFormatter.Format(secondaryCountryRecipientList));
       emailBlock.Post(emailApiParams);
       log.Info(...);
    }
    emailBlock.Complete();
    await emailBlock.Completion();
    
