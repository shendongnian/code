        private void btnExpandR_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            TreeNode tempnode = treeView.Nodes[0].Clone() as TreeNode;
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += NodeCopy;
            bw.RunWorkerAsync(tempnode);
        }
        private void NodeCopy(object sender, RunWorkerCompletedEventArgs e)
        {
            treeView.Nodes[0] = e.Result as TreeNode;
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            TreeNode tempNode = e.Argument as TreeNode;
            Exp(tempNode);
            e.Result = tempNode;
        }
        private void Exp(TreeNode tn)
        {
            tn.Expand();
            foreach(TreeNode t in tn.Nodes)
            {
                if(t.Nodes.Count > 0)
                {
                    exp(t);
                }
            }
        }
