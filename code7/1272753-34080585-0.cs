	[Route("api/branches/{id}/devices")]
	public async Task<IHttpActionResult> PutDevice(int id, Device device)
	{
	    Branch branch = await  db.Branches.Include("devices").FirstAsync(b => b.id == id);
	    Device dbDevice = await  db.Devices.Find(device.id);
	    if (!ModelState.IsValid)
	    {
	        return BadRequest(ModelState);
	    }
	    if (branch == null || dbDevice == null)
	    {
	        return NotFound();
	    }
	    dbDevice.branch = branch;
	    try
	    {
	        await db.SaveChangesAsync();
	    }
	    catch (DbUpdateConcurrencyException)
	    {
	        if (!BranchExists(id))
	        {
	            return NotFound();
	        }
	        else
	        {
	            throw;
	        }
	    }
	    return StatusCode(HttpStatusCode.NoContent);
	}
