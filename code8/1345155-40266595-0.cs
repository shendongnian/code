    public static class StaticResourceConventionBuilder
    {
        public static Func<NancyContext, string, Response> AddDirectory(string requestedPath, Assembly assembly, string namespacePrefix)
        {
            return (context, s) =>
            {
                var path = context.Request.Path;
                if (!path.StartsWith(requestedPath))
                {
                    return null;
                }
                string resourcePath;
                string name;
                var adjustedPath = path.Substring(requestedPath.Length + 1);
                if (adjustedPath.IndexOf('/') >= 0)
                {
                    name = Path.GetFileName(adjustedPath);
                    resourcePath = namespacePrefix + "." + adjustedPath
                        .Substring(0, adjustedPath.Length - name.Length - 1)
                        .Replace('/', '.');
                }
                else
                {
                    name = adjustedPath;
                    resourcePath = namespacePrefix;
                }
                return new EmbeddedFileResponse(assembly, resourcePath, name);
            };
        }
    }
