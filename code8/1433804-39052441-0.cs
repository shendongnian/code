    private TreeNode[] RecurseTree(Dictionary<string, object> dic)
        {
            List<TreeNode> branch = new List<TreeNode>();
            foreach (KeyValuePair<string, object> kvp in dic)
            {
                TreeNode twig = new TreeNode(kvp.Key);
                if (kvp.Value is string)
                {
                    twig.Nodes.Add(new TreeNode(kvp.Value.ToString()));
                }
                else
                {
                    twig.Nodes.AddRange(RecurseTree((Dictionary<string,object>)kvp.Value));
                }
                branch.Add(twig);
            }
            return branch.ToArray();
        }
