     public static void ThrowIfNull(this object obj)
        {
           if (obj == null)
                throw new Exception();
        }
