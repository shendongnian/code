    listBox1.SelectedIndexChanged += listBox_SelectedIndexChanged;
    listBox2.SelectedIndexChanged += listBox_SelectedIndexChanged;
    private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        var listBox = sender as ListBox;
        if(sender != null) MessageBox.Show(sender.Name);
    }
