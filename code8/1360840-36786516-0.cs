    // Form 1
    public void button1_Click(object sender, EventArgs e)
    {
        form1 view = new form();
        view.Show();
        view.label1 = label1;
    }
    // Form 2
    
    public Label label1 { get; set; }
    
    public void Display()
    {
        if (label1.Text == "1")
        {
            for (int i = 0; i < nWinnings.Length; i++)
            {
                label1.BackColor = Color.Red;
                // ... etc, etc
