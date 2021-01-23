    [ResponseType(typeof(DataDictionary))]
    public async Task<IHttpActionResult> GetDataDictionary(int id)
    {
        DataDictionary dataDictionary = await db.DataDictionaries
            .Include(x=>x.Children)
            .FirstOrDefaultAsync(x=>x.Id == id);
        if (dataDictionary == null)
        {
            return NotFound();
        }
        return Ok(dataDictionary);
     }
