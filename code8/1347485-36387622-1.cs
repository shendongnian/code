    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (this.underlyingConnection.State == ConnectionState.Open)
            {
                this.underlyingConnection.Close();
            }
    
            this.underlyingConnection.Dispose();
        }
    }
