    private void chechTreeViewItems(List<int> remID)
        {
            for (int i = 0; i < remID.Count; i++)
            {
                foreach (System.Windows.Forms.TreeNode item in this.tvRemark.Nodes[0].Nodes)
                {
                    if (Convert.ToInt16(item.Tag) == remID[i])
                    {
                        item.Checked = true;
                    }
                }
            }
        }
