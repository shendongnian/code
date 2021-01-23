    public async Task Get()
    {
        var cancellation = Request.GetOwinContext().Request.CallCancelled;
        await database.FooAsync(cancellation);
    }
