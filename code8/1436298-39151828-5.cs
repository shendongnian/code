    [HttpPost]
    public async Task<IHttpActionResult> PostZoo(Zoo item) {
      // replace child entities with those from the context (so they are tracked)
      if (item.Animals.Any()) {
        // find animals which are already in the db
        var ids = item.Animals.Select(x => x.Id);
        var oldItems = context.Animals.Where(x => ids.Contains(x.Id)).ToList();    
        var newItems = item.Animals.Where(x => !oldItems.Select(y => y.Id).Contains(x.Id));
        // add new animals if there are any
        if (newItems.Any()) {
          foreach (var i in newItems) {
            context.Animals.Add(i);
          }
          await context.SaveChangesAsync();
        }
        // replace
        item.Animals.Clear();
        foreach (var i in oldItems) item.Animals.Add(i);
        foreach (var i in newItems) item.Animals.Add(i);
      }
      // now add the Zoo (which contains tracked Animal entities)
      Zoo current = await InsertAsync(item);
      return CreatedAtRoute("Tables", new { id = current.Id }, current);
    }
