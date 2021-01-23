        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Columns.Add("No");
            listView1.View = View.Details;
            for (int i = 0; i < 9; i++)
            {
                // keep a temporary reference of the new nodes/items..
                ListViewItem lvi = listView1.Items.Add("Item " + i);
                TreeNode tn =  treeView1.Nodes.Add("Item " + i);
                // ..and store them in the respective tags:
                lvi.Tag = tn;
                tn.Tag = lvi;
            }
        }
