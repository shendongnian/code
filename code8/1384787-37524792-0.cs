    public static class EX
    {
        public static int ToInt32(this object o)
        {
            if (o == null)
            {
                return default(int);
            }
            return Convert.ToInt32(o);
        }
    }
