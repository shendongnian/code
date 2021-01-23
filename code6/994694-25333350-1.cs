    public async Task<IHttpActionResult> GetMyMessage(int id)
    {
        var messages = await db.Messages.Where(a => a.Group.Id == id).ToListAsync();
        var models = messages.Select(
            m => new MessageViewModel {
                Id = m.Id, 
                Name = m.Name
            }).ToList();
        return Ok(models);
    }
