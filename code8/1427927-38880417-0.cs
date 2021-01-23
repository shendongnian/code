    public async Task<IHttpActionResult> Delete(Item item)
    {                
        var i = await _db.Item.FirstOrDefaultAsync(x => x.id == item.id);
        _db.Item.Remove(i);
        _db.SaveChanges();
        return Ok(true);
    }
