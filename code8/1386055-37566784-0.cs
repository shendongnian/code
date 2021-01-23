    static List<string> _graph = new List<string>() { "ab", "aj", "ad", "ae", "bd", "bc", "bd", "bg", "bj", "dj" };
    static void Main(string[] args)
    {
        string longest = string.Empty; // Result will be here.
        foreach (string node in _graph)
            GenerateChildren(node,ref longest);
    }
    static void GenerateChildren(string parent, ref string longest)
    {
        // Store longest path.
        if (parent.Length > longest.Length)
            longest = parent;
        foreach (string child in _graph.Where(child=>parent.EndsWith(child.Substring(0,1))))
            GenerateChildren(parent+child.Substring(1),ref longest);
    }
