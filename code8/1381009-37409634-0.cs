    List<string> Paths = Directory.GetFiles(Directoria, "*.sql", SearchOption.TopDirectoryOnly).
        Select(f => {
            int version;
            string[] parts = Path.GetFileName(f).Split('_');
            if (parts.Length < 1 || !int.TryParse(parts[0], out version))
                version = -1;
            return new {File = f, Version = version};
        }).
        Where(f => f.Version > -1).
        OrderBy(f => f.Version).
        Select(f => f.File).ToList();
