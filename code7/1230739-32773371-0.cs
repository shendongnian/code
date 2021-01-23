    private void Form1_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Properties.Settings.Default.CheckIndices))
        {
            Properties.Settings.Default.CheckIndices.Split(',')
                .Select(x=>int.Parse(x))
                .ToList()
                .ForEach(index =>
                {
                    this.checkedListBox1.SetItemChecked(index, true);
                });
        }
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        var indices = this.checkedListBox1.CheckedIndices.Cast<int>()
            .Select(x => x.ToString())
            .ToArray();
        Properties.Settings.Default.CheckIndices = string.Join(",", indices);
        Properties.Settings.Default.Save();
    }
