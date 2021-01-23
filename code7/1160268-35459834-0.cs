    public static class PlatformServicesExtensions
    {
        public static string MapPath(this PlatformServices services, string path)
        {
            var result = path ?? string.Empty;
            var appPath = services.Application.ApplicationBasePath;
            var wwwroot = Path.Combine(appPath, "wwwroot");    // todo: take it from project.json!
            if (result.StartsWith("~", StringComparison.Ordinal)) { result = result.Substring(1); }
            if (result.StartsWith("/", StringComparison.Ordinal)) { result = result.Substring(1); }
            result = Path.Combine(wwwroot, result.Replace('/', '\\'));
            return result;
        }
        public static string UnmapPath(this PlatformServices services, string path)
        {
            var result = path ?? string.Empty;
            var appPath = services.Application.ApplicationBasePath;
            var wwwroot = Path.Combine(appPath, "wwwroot");    // todo: take it from project.json!
            result = result.Remove(0, wwwroot.Length);
            result = result.Replace('\\', '/');
            return (result.StartsWith("/", StringComparison.Ordinal) ? "~" : "~/") + result;
        }
    }
