    public static class Extenstions
    {
        public static bool Contains(this DataRowCollection c, params object[] args)
        {
            return c.Contains(args);
        }
    }
