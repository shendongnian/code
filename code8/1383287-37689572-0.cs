       public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Plato> patch)
        {
            Validate(patch.GetEntity());
    
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            Plato plato = await db.Platos.FindAsync(key);
            if (plato == null)
            {
                return NotFound();
            }
    //Here save the current value in the DB
            string timeStamp = Convert.ToBase64String(plato.TimeStamp);
            patch.Put(plato);
    
            try
            {
    //Here plato.TimeStamp is update from remote, must be equal to stored value
                if (timeStamp != Convert.ToBase64String(plato.TimeStamp))
                {
                    throw new DbUpdateConcurrencyException();
                }
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
    
            return Updated(plato);
        }
