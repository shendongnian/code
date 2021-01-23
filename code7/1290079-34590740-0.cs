    private IEnumerable<string> textures;
    private void Form1_Load(object sender, EventArgs e)
    {
        this.textures = LoadTextures();
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(textBox1.Text))
        {
            listView1.Items.Clear();
            FillListView(item => item.ToLower().Contains(textBox1.Text.ToLower()));
            if (listView1.SelectedItems.Count == 1)
                listView1.Focus();
        }
        else
            FillListView();
    }
    private void FillListView(Func<string, bool> filter = null)
    {
        var items = filter == null ? this.textures : this.textures.Where(filter);
        foreach (var item in items)
            listView1.Items.Add(item);
    }
    private IEnumerable<string> LoadTextures()
    {
        return Directory.GetFiles("path", "*.png");
    }
