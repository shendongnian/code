    [HttpPost]
    public async void DoStuff(string id)
    {
        EstateContext db = new EstateContext();
        var entity = await db.Estates.FindAsync(id);
        db.SaveChanges();
    }
