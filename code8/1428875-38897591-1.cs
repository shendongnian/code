    public static class MyDatabaseContextFactory
    {
        public static MyDatabaseContext Create(Uri uri)
        {
            return new MyDatabaseContext(uri.GetTopDomain());
        }
    }
