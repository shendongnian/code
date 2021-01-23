    using (var ctx = GetContext())
    {
        using (var transactionScope = new TransactionScope())
        {
            var entities= new List<TagUser>();
            foreach (string tag in tags)
            {
                TagUser tagUser = new TagUser()
                {
                    //Initialize TagUser
                    TagId = ..., // get something like tag.Id
                    Id = applicationUser.Id
                };
                entities.Add(tagUser);
            }
            ctx.BulkInsert(entities);
            ctx.SaveChanges();
            transactionScope.Complete();
        }
    }
