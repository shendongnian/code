    static IEnumerable<TreeItem<category>> GetLeafs(IEnumerable<TreeItem<category>> tree) 
    {
        foreach (var item in tree)
        {
            if (item.Children.Any()) 
            {
                // this is not a leaf, so find the leaves in its descendants
                foreach (var leaf in GetLeafs(item.Children))
                    yield return leaf;                
            }
            else
            {
                // no children, so this is a leaf
                yield item;                
            }
        }
    }
    
    static void CreateDirectories(IEnumerable<TreeItem<category>> categories)
    {
        foreach (var leaf in GetLeafs(categories)) 
        {
            System.IO.Directory.CreateDirectory(leaf.Item.Name);
        }
    }
