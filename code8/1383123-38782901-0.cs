    var contactResults = await client.Me.Contacts
                    .OrderBy(c => c.DisplayName)
                    .Select(c => new DisplayContact(c))
                    .ExecuteAsync();
    while (true)
    {
        foreach (DisplayContact displayContact in contactResults.CurrentPage)
            System.Diagnostics.Debug.WriteLine(displayContact);
        if (contactResults.MorePagesAvailable)
            contactResults = await contactResults.GetNextPageAsync();
        else
            break;
    }
