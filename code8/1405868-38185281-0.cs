        public static Version GetFileVersion(this Assembly assembly)
        {
            AssemblyFileVersionAttribute attribute = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            return attribute == null ? null : new Version(attribute.Version);
        }
