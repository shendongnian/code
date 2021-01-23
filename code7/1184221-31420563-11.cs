    Container container = new Container(new Uri("http://..."));
    Entity entity = new Entity();
    ...
    entity.Email = "xxxx";
    container.AddToEntities(entity);
    container.SaveChanges();
