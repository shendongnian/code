    private void Form1_Load(object sender, EventArgs e)
    {
        label1.Click += Label1_Click;
    }
    private void Label1_Click(object sender, EventArgs e)
    {
        if (tabControl1.Visible) 
        { 
            tabControl1.Hide(); 
        } else 
        {
            tabControl1.Show();
        }
    }
