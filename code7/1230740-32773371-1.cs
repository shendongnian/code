    private void Form1_Load(object sender, EventArgs e)
    {
        //Load List of Items
        //Or I assume that Items has been added in InitializeComponent
        if (!string.IsNullOrEmpty(Properties.Settings.Default.CheckedIndices))
        {
            Properties.Settings.Default.CheckedIndices.Split(',')
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
        Properties.Settings.Default.CheckedIndices = string.Join(",", indices);
        Properties.Settings.Default.Save();
    }
