    string query = "Example keywords in field <Keywords>";
    Guid searchPageEventGuid = Sitecore.Context.Database.GetItem("{0C179613-2073-41AB-992E-027D03D523BF}").ID.Guid;
    Guid view4Guid = Sitecore.Context.Database.GetItem("{D0D0E48C-7DE0-4C95-A994-F5ED00DC9820}").ID.Guid;
    var page = Tracker.Current.Interaction.CurrentPage;
    page.Register(new PageEventData("My search page event data", searchPageEventGuid)
                    {
                        ItemId = view4Guid,
                        Data = query,
                        DataKey = query,
                        Text = query,
                    });
   
