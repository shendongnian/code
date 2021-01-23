    var predicate = PredicateBuilder.False<Contact>();
    foreach (var tagId in tagIds)
    {
        predicate.And(x => x.Tags.Any(tag => tag.Id.ToString() == tagId));
    }
    context.Contacts.Include("Tags").Where(predicate).ToList();
