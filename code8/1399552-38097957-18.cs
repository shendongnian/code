    public ObjectQuery<T> Include(string path)
    {
        Check.NotEmpty(path, "path");
        return new ObjectQuery<T>(QueryState.Include(this, path));
    }
