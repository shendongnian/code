    [Route("Postitem")]
    [ResponseType(typeof(Item))]
    public async Task<IHttpActionResult> PostItem(Item item)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        db.items.Add(item);
        await db.SaveChangesAsync();
        return this.Ok(new { id = item.Id });
    }
