    private void Form1_Load(object sender, EventArgs e)
    {
        var list = Enumerable.Range(1, 10)
            .Select(x => new { A = x, B = $"x" })
            .ToSortableBindingList();
        dataGridView1.DataSource = list;
    }
