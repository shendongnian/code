    protected async Task<IActionResult> PostItem(Item item)
    {
      _DbContext.Items.Add(item);
      try
      {
        await _DbContext.SaveChangesAsync();
      }
      catch (DbUpdateException e)
      when (e.InnerException?.InnerException is SqlException sqlEx && 
        (sqlEx.Number == 2601 || sqlEx.Number == 2627))
      {
        return BadRequest("Cannot store duplicate items.");
      }
      return Ok();
    }
