    // get the ID of the entity
	var metaData = session.SessionFactory.GetClassMetadata(type);
    var id = metaData.GetIdentifier(unproxiedEntity);
    // load the entity and delete it
    var attachedEntity = session.Get(type, id);
    session.Delete(attachedEntity);
