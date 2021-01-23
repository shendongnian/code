    private void button_click(object sender, EventArgs e)
    {
        if (tv.SelectedNode != null)
            tv.SelectedNode.Text = Interaction.InputBox("Rename the node name from " + tv.SelectedNode.Text);
    }
