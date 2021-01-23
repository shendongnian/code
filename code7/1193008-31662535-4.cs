    public static class TypeUtils
    {
        public static Type FindType(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.IsDynamic)
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.Name.Equals(name));
        }
    }
