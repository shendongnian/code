    private async void GetMeSomeDataToolStripMenuItem_Click(object sender, EventArgs e)
    {
       TabControl t = await Task<TabControl>.Run(GetData);
       tabControl1 = t;
    }
