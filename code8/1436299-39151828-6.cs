    [HttpPost]
    public async Task<IHttpActionResult> PostZoo(Zoo item) {
      // replace child entities with those from the context (so they are tracked)
      if ((item.Animals != null) && item.Animals.Any()) {
        // find animals which are already in the db
        var ids = item.Animals.Select(x => x.Id);
        var oldAnimals = _context.Animals.Where(x => ids.Contains(x.Id)).ToList();
        var newAnimals = item.Animals.Where(x => !oldAnimals.Select(y => y.Id).Contains(x.Id));
        // don't allow new animal entities
        if (tagsNew.Any()) {
          var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
          var body = new JObject(new JProperty("error", "New Animals must be added first"));
          response.Content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
          throw new HttpResponseException(response);
          }
        // replace 
        item.Animals.Clear();
        foreach (var i in oldAnimals) item.Animals.Add(i);
        }
      // now add the Zoo (which contains tracked Animal entities)
      Zoo current = await InsertAsync(item);
      return CreatedAtRoute("Tables", new { id = current.Id }, current);
      }
