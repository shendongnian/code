    private void UpdateNode()
    {
       // This line is best moved to where you initially populate the nodes.
       treeView1.SelectedNode.Tag = treeView1.SelectedNode.Text;
       var words = new List<string>();
       if (ckbAnswer1.Checked)
       {
          words.Add("A");
       }
       if (ckbAnswer2.Checked)
       {
          words.Add("B");
       }
       if (ckbAnswer3.Checked)
       {
          words.Add("C");
       }
       var answers = " - none";
       if (words.Count > 0) {
          answers = " - " +  string.Join(", ", words);
       }
       treeView1.SelectedNode.Text = treeView1.SelectedNode.Tag.ToString() + answers;
    }
