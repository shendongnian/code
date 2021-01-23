    List<string> lines = new List<string>();
    public void LoadFile(string file)
    {
        lines = File.ReadAllLines(file).ToList();
    }
