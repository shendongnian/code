    List<int> destinationIds = ...;
    var letterEntity = new LetterEntity { ... };
    letterEntity.Links = destinationIds.Select(destinationId =>
        new LetterDestinationLink { Letter = letterEntity, DestinationId = destinationId })
        .ToList();
    context.Set<LetterEntity>().Add(letterEntity);
    context.SaveChanges();
 
