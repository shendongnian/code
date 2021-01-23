    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNodeText = e.Node.Text;
            //Ensure that this is not a directory node
            if (e.Node.Tag != null) {
                string location = e.Node.Tag; 
                mediaPlayer.URL = location;
            }
        }
