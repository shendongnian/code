    public static T CheckNull<T>(Func<T> canBeNull) where T : class
        {
            try
            {
                return canBeNull();
            }
            catch (NullReferenceException)
            {
                return default(T);
            }
        }
