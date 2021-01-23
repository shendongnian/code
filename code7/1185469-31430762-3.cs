        private void GetDirectoryNodes(string path, TreeNode node)
        {
            try
            {
                var subDirs = Directory.GetDirectories(path);
                foreach (string p in subDirs)
                {
                    var subnode = new TreeNode(p);
                    backgroundWorker1.ReportProgress(
                        1, 
                        new Tuple<TreeNode, TreeNode>(
                            node, subnode
                            ));
                    GetDirectoryNodes(p, subnode); // recursive!
                }
            }
            catch (Exception exp)
            {
                var subnode = new TreeNode(path+"\\error");
                subnode.ToolTipText = exp.Message;
                backgroundWorker1.ReportProgress(
                    1, 
                    new Tuple<TreeNode, TreeNode>(
                        node, subnode
                        ));
            }
        }
