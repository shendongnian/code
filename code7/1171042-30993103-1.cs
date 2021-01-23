    public static void Main()
    {
        var rootNode =
            new TreeNode("node-0",
                new TreeNode("node-1",
                    new TreeNode("node-2", 20)),
                new TreeNode("node-3", 19),
                new TreeNode("node-4",
                    new TreeNode("node-5", 25),
                    new TreeNode("node-6", 40)));
    
    
        var result = ReadHierarchy(new List<TreeNode> {rootNode});
    
        foreach (var r in result)
        {
            Console.WriteLine("{0} - {1}", r.Key, r.Value);
        }
    
        Console.ReadKey();
    }
    
    private static Dictionary<string, object> ReadHierarchy(IEnumerable<TreeNode> collection)
    {
        return collection.ToDictionary(node => node.Id,
            node => node.Children.Count > 0 ? ReadHierarchy(node.Children) : node.Data as object);
    }
