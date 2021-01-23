    var entity = unitOfWork.EntityRepository.GetById(model.Id);
    // I have something like this to load collection because
    // I don't have the collection's entities exposed to the context
    unitOfWork.EntityRepository.LoadCollection(entity, e => e.CollectionProperty);
    entity.CollectionProperty = newCollectionValuesList;
    unitOfWork.Save();
