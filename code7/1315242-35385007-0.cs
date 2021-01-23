    private List<string> Source()
    {
        var testItems = new List<string>();
        for (int i = 1; i < 1000; i ++)
        {
            testItems.Add(i.ToString());
        }
        return testItems;
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var topTenMatches = this.Source().Where(s => s.Contains(textBox1.Text)).Take(10);
        var autoCompleteSource = new AutoCompleteStringCollection();
        autoCompleteSource.AddRange(topTenMatches.ToArray());
        textBox1.AutoCompleteCustomSource = autoCompleteSource;
    }
