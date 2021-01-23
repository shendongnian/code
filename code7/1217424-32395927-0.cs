    public static class Builder
    {
        public static T Build<T>(params object[] args) where T : class
        {
            var info = typeof(T).GetConstructor(args.Select(arg => arg.GetType()).ToArray());
            if (info == null)
                throw new ArgumentException(@"Can't get constructor :(", "args");
            return (T)info.Invoke(args.ToArray());
        } 
    }
