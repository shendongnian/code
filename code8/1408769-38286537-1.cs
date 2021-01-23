    var predicate = PredicateBuilder.True<Contact>();
    foreach (var tagId in tagIds)
    {
        predicate = predicate.Or(c => c.Tags.Any(tag => tag.Id.ToString() == tagId));
    }
    var contactsByTags = context.Contacts.Include("Tags").Where(predicate).ToList();
