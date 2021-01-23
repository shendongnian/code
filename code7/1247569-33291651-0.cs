    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (Button b in Controls.OfType<Button>())
        {
            b.Click += MakeSoundEffect;
        }
    }
    private void MakeSoundEffect(object sender, EventArgs e)
    {
        // Do something
    }
