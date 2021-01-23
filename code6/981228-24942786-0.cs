    rooteNode.Flatten()
        .Last(x => x.Text == "Folder1.1")
        .Nodes.Add("File1.1.1");
---
    public static class TreeNodeHelper
    {
        public static IEnumerable<TreeNode> Flatten(this TreeNode root)
        {
            yield return root;
            
            foreach(TreeNode node in root.Nodes)
                foreach(var item in Flatten(node))
                    yield return item;
        }
    }
