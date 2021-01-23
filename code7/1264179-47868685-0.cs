    public static class ContainerBuilderExtensions
    {
        public static void ScanAssembly(this ContainerBuilder builder, string searchPattern = "SolutionName.*.dll")
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var assembly in Directory.GetFiles(path, searchPattern).Select(Assembly.LoadFrom))
            {
                builder.RegisterAssemblyModules(assembly);
            }
        }
    }
