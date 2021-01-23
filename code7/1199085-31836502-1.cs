    public List<string> GetAllFiles(string path) {
        if (!Directory.Exists(path)) {
            return new List<string>();
        }
        try {
            return Directory.GetDirectories(path).SelectMany(folder => GetAllFiles(folder))
                .Concat(Directory.GetFiles(path)).ToList();
        } catch (Exception) {
            return new List<string>();
        }
    }
