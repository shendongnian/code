    public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Product> product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var entity = await db.Products.FindAsync(key);
        if (entity == null)
        {
            return NotFound();
        }
        product.Patch(entity);
        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return Updated(entity);
    }
