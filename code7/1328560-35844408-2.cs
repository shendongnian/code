    public static class ServerPathUtility {
        public static string ResolveOrCreatePath(string pathToReplace) {
            string rootedFileName = ResolvePhysicalPath(pathToReplace);
            FileInfo fi = new FileInfo(rootedFileName);
            try {
                DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
                if (!di.Exists) {
                    di.Create();
                }
                if (!fi.Exists) {
                    fi.CreateText().Close();
                }
            } catch {
                // NO-OP
                // TODO: Review what should be done here.
            }
            return fi.FullName;
        }
        public static string ResolvePhysicalPath(string pathToReplace) {
            string rootedPath = ResolveFormat(pathToReplace);
            if (rootedPath.StartsWith("~") || rootedPath.StartsWith("/")) {
                rootedPath = System.Web.Hosting.HostingEnvironment.MapPath(rootedPath);
            } else if (!Path.IsPathRooted(rootedPath)) {
                rootedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rootedPath);
            }
            return rootedPath;
        }
        public static string ResolveFormat(string format) {
            string result = format;
            try {
                result = ExpandApplicationVariables(format);
            } catch (System.Security.SecurityException) {
                // Log?
            }
            try {
                string variables = Environment.ExpandEnvironmentVariables(result);
                // If an Environment Variable is not found then remove any invalid tokens
                Regex filter = new Regex("%(.*?)%", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                string filePath = filter.Replace(variables, "");
                if (Path.GetDirectoryName(filePath) == null) {
                    filePath = Path.GetFileName(filePath);
                }
                result = filePath;
            } catch (System.Security.SecurityException) {
                // Log?
            }
            return result;
        }
        public static string ExpandApplicationVariables(string input) {
            var filter = new Regex("{(.*?)}", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            var result = filter.Replace(input, evaluateMatch());
            return result;
        }
        private static MatchEvaluator evaluateMatch() {
            return match => {
                var variableName = match.Value;
                var value = GetApplicationVariable(variableName);
                return value;
            };
        }
        public static string GetApplicationVariable(string variable) {
            string value = string.Empty;
            variable = variable.Replace("{", "").Replace("}", "");
            var parts = variable.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            variable = parts[0];
            var parameter = string.Empty;
            if (parts.Length > 1) {
                parameter = string.Join("", parts.Skip(1));
            }
            Func<string, string> resolve = null;
            value = VariableResolutionStrategies.TryGetValue(variable.ToUpperInvariant(), out resolve) && resolve != null
                ? resolve(parameter)
                : string.Empty;
            return value;
        }
        public static readonly IDictionary<string, Func<string, string>> VariableResolutionStrategies =
            new Dictionary<string, Func<string, string>> {
                {"MACHINENAME", p => Environment.MachineName },
                {"APPDOMAIN", p => AppDomain.CurrentDomain.FriendlyName },
                {"DATETIME", getDate},
                {"DATE", getDate},
                {"UTCDATETIME", getUtcDate},
                {"UTCDATE", getUtcDate},
            };
        static string getDate(string format = "yyyy-MM-dd") {
            var value = string.Empty;
            if (string.IsNullOrWhiteSpace(format))
                format = "yyyy-MM-dd";
            value = DateTime.Now.ToString(format);
            return value;
        }
        static string getUtcDate(string format = "yyyy-MM-dd") {
            var value = string.Empty;
            if (string.IsNullOrWhiteSpace(format))
                format = "yyyy-MM-dd";
            value = DateTime.Now.ToString(format);
            return value;
        }
    }
