    private HttpContent content;
    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !disposed)
        {
            disposed = true;
            if (content != null)
            {
                content.Dispose();
            }
        }
    }
