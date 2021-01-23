    private void ckbAnswerA_CheckedChanged(object sender, EventArgs e)
    {
        if (ckbAnswerA.Checked)
        {
            updateAnswerA(true);
        }
        else
        {
            updateAnswerA(false);
        }
    }
    
    private void updateAnswerA(bool flag)
    {
        if(flag)
        {
            var words = new List<string>();
            words.Add("A,");
            treeView1.SelectedNode.Text += string.Join(" ", words);
        }
        else
        {
            string update = treeView1.SelectedNode.Text;
            update = update.Replace("A,", "");
            treeView1.SelectedNode.Text = update;
        }
    }
