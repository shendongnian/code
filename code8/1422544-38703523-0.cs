    private void button1_Click(object sender, EventArgs e)
    {
        this.dataGridView1.Margin = new Padding(0);
        var host = new ToolStripControlHost(this.dataGridView1);
        this.dataGridView1.MinimumSize = new Size(200, 100);
        host.Padding = new Padding(0);
        var c = new ToolStripDropDown();
        c.Items.Add(host);
        c.Show(button1, 0,button1.Height);
    }
