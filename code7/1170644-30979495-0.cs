    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // dispose managed resources
            if (BackgroundWorker != null)
            {
                BackgroundWorker.Dispose(); or BackgroundWorker.Close();
                BackgroundWorker = null;
            }
            // Dispose remaining objects,
        }
    }
}
