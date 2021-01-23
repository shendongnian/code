    public async Task<ActionResult> GetLocation(int id)
    {
        var listing = await db.Listings.FindAsync(id);
        ...
        var gr = await geo.Geocode(li.BizAddress);
