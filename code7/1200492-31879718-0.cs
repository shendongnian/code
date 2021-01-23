    IMongoCollection<Profile> dbCollection = DetermineCollectionName<Profile>();
    var filter = Builders<Profile>.Filter.In(x => x.ID, profiles.Select(x => x.ID));
    var profile2maillists = new List<Profile2MailList>();
    foreach(var profile in profiles)
     {
         profile2maillists.Add(
             new Profile2MailList
                     {
                                MailListId = maillistId,
                                Status = profile.MailLists.MergeMailListStatuses(),
                                SubscriptionDate = DateTime.UtcNow
                     });
     }
    var updateMl = Builders<Profile>.Update.AddToSetEach(p => p.MailLists, profile2maillists);
    dbCollection.UpdateManyAsync(filter, updateMl, new UpdateOptions { IsUpsert = true });
