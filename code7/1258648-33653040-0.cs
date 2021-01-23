    private void button1_Click(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn.Left = nTotalWidth;
    
        panel1.Controls.Add(btn);
        nTotalWidth += btn.Width;
    }
