    public MemoryStream d()
    {
        MemoryStream ms;
        try
        {
            ms = new MemoryStream()
        }
        finally
        {
            ms.Dispose();
            return ms;
        }
    }
