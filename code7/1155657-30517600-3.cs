    class IniFile : Dictionary<string,Dictionary<string,string>> {
        public IniFile(string filename) {
            var currentSection = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Add("", currentSection);
            foreach (var line in File.ReadAllLines(filename)) {
                var trimedLine = line.Trim();
                switch (line[0]) {
                    case ';':
                        continue;
                    case '[':
                        currentSection = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                        Add(trimedLine.Substring(1, trimedLine.Length - 2), currentSection);
                        break;
                    default:
                        var parts = trimedLine.Split('=');
                        if (parts.Length > 1) {
                            currentSection.Add(parts[0].Trim(), parts[1].Trim());
                        }
                        break;
                }
            }
        }
        public string this[string sectionName, string key] {
            get {
                Dictionary<string, string> section;
                if (!TryGetValue(sectionName, out section)) { return null; }
                string value;
                if (!section.TryGetValue(key, out value)) { return null; }
                return value;
            }
        }
        public int? GetInt(string sectionName, string key) {
            string stringValue = this[sectionName, key];
            int result;
            if (!int.TryParse(stringValue, out result)) { return null; }
            return result;
        }
    }
