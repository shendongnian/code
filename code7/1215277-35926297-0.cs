    var profilesWithMailListsAlt =
        profilesWithCf.Join(
            profile2Maillist.GroupBy(p2l => p2l.ProfileId),
            p => p.SqlId,
            p2lgroup => p2lgroup.Key,
            (p, mailListGroup) =>
            {
                var p2lmongo = mailListGroup.Select<TProfile2MailList, Profile2MailList>(p2l =>
                {
                    return new Profile2MailList
                    {
                        MailListId = p2l.MailListId,
                        Status = p2l.Status,
                        SubscriptionDate = p2l.SubscriptionDate
                    };
                });
                p.MailLists = p2lmongo.ToArray();
                return p;
            });
