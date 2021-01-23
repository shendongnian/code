    [HttpPost]
    public async Task<ActionResult> DoStuff(string id)
    {
        var entity = await _db.Estates.FindAsync(id);
        _db.SaveChanges();
    }
