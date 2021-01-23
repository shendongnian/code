    public List<string> GetAllFiles(string path) {
        var res = new List<string>();
        if (Directory.Exists(path)) {
            try {
                foreach (var folder in Directory.GetDirectories(path)) {
                    res.AddRange(GetAllFiles(folder));
                }
                foreach (var file in Directory.GetFiles(path)) {
                    res.Add(file);
                }
            } catch (Exception) {
                // ignored
            }
        }
        return res;
    }
