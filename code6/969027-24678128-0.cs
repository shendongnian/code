    static class PropertiesFileReader
    {
        private static string PathToPropertiesFile = @"application.properties";
        private static Regex subRegex = new Regex(@"\$\{.*\}");
        /// <summary>
        /// Parses the properties file into a map 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> ReadProperties() {
            var data = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines(PathToPropertiesFile))
            {
                var newRow = String.Empty;
                // ignore any rows that are commented out
                // or do not contain an equals sign
                if (!row.StartsWith("#") && row.Contains("="))
                {
                    // replace each instance of a variable placeholder in the property value
                    foreach (Match match in subRegex.Matches(row))
                    {
                        var key = Regex.Replace(match.ToString(), @"[${}]", String.Empty);
                        var replaceValue = data[key];
                        newRow = row.Replace(match.ToString(), replaceValue);
                    }
                    // add the property key and value
                    if (!String.IsNullOrEmpty(newRow))
                    {
                        data.Add(newRow.Split('=')[0], string.Join("=", newRow.Split('=').Skip(1).ToArray()));
                    }
                    else
                    {
                        data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                    }
                }
                
                
            }
                
            return data;
            
        }
 
    }
