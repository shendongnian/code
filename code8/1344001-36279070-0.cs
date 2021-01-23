    protected void Click_Click(object sender, EventArgs e)
    {
        string[] lines = File.ReadAllLines("D:\\mun.txt");
        var content = String.Join(System.Environment.NewLine, lines);
        TextBox1.Rows = lines.Length;
        TextBox1.Text = content;
        Regex regex = new Regex("\\w+");
        var frequencyList = regex.Matches(content)
            .Cast<Match>()
            .Select(c => c.Value.ToLowerInvariant())
            .GroupBy(c => c)
            .Select(g => new { Word = g.Key, Count = g.Count() })
            .OrderByDescending(g => g.Count)
            .ThenBy(g => g.Word);
        Dictionary<string, int> dict = frequencyList.ToDictionary(d => d.Word, d => d.Count);
        foreach (var item in frequencyList)
        {
            Label1.Text = Label1.Text + item.Word + "<br />";
            Label2.Text = Label2.Text + item.Count.ToString() + "<br />";
        }
    }
