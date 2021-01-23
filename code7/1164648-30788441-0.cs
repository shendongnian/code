        private string[] FullKeyPath(TreeNode tn)
        {
            string[] path = new string[tn.Level + 1];
            for (int i = tn.Level; i >= 0; i--)
            {
                path[i] = tn.Name.ToString();
                if (tn.Parent != null)
                {
                    tn = tn.Parent;
                }
            }
            return path;
        }
