    public static class Ext
    {
        public static T CastOrDefault<T>(this object obj)
        {
            return obj is T ? (T)obj : default(T);           
        }
    }
    ...
    bool isLolCat = RouteData["isLolCat"].CastOrDefault<bool>();
