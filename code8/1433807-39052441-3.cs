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
                else if (kvp.Value is Dictionary<string, object>)
                {
                    twig.Nodes.AddRange(RecurseTree((Dictionary<string, object>)kvp.Value));
                }
                else
                {
                    IEnumerable enumerable = (kvp.Value as IEnumerable);
                    if(enumerable != null)
                    {
                      foreach(var item in enumerable)
                      {
                        twig.Nodes.Add(new TreeNode(item.ToString()));
                      }
                    }
                }
                branch.Add(twig);
            }
            return branch.ToArray();
        }
