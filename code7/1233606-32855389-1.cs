    private void timer1_Tick(object sender, EventArgs e)
    {
        this.listBox1.BeginUpdate();
        this.listBox1.Items.Clear();
        for (int i = 0; i < 100; i++)
        {
            this.listBox1.Items.Add(i);   
        }
        this.listBox1.EndUpdate();
    }
