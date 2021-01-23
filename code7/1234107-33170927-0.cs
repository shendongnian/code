    {
    .............
    TreeNode tn = new TreeNode(this.DataGridView2.Rows[0].Cells[0].Value.ToString());//text
    tn.Tag = this.DataGridView2.Rows[0].Cells[4].Value.ToString();// id
    tn.Name = this.DataGridView2.Rows[0].Cells[5].Value.ToString();//directorid
                    treeView1.Nodes.Add(tn);
                    settree(tn);
                }
                public void settree(TreeNode ns)
            {
                foreach (DataGridViewRow dr in DataGridView2.Rows)
                {
                    if (dr.Cells[5].Value.ToString() == ns.Tag.ToString())
                    {
                        TreeNode tsn = new TreeNode(dr.Cells[0].Value.ToString());
                        tsn.Tag = dr.Cells[4].Value.ToString();
                        tsn.Name = dr.Cells[5].Value.ToString();
                        ns.Nodes.Add(tsn);
                        settree(tsn);
                    }
                }
            }
