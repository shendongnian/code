    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            DAL.Dispose();
        }
        base.Dispose(disposing);
    }
