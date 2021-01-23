    private void Form1_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Properties.Settings.Default.CheckedItems))
        {
            Properties.Settings.Default.CheckedItems.Split(',')
                .ToList()
                .ForEach(item =>
                {
                    var index = this.checkedListBox1.Items.IndexOf(item);
                    this.checkedListBox1.SetItemChecked(index, true);
                });
        }
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        var indices = this.checkedListBox1.CheckedItems.Cast<string>()
            .ToArray();
        Properties.Settings.Default.CheckedItems = string.Join(",", indices);
        Properties.Settings.Default.Save();
    }
