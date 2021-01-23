    ~TempFileProxy() { 
        Dispose(false);
    }
    public void Dispose() { 
        Dispose(true); 
    }
    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            GC.SuppressFinalize(this);                
        }
        if (this.FullPath != null)
        {
            try { 
                File.Delete(this.FullPath); 
            }
            catch { }
            this.FullPath = null;
        }
    }
