    Random random = new Random();
    
    private Color GetRandomColor()
    {
        return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
    }
    
    private void btnStart_Click(object sender, EventArgs e)
    {
        button1.BackColor = GetRandomColor();
        button2.BackColor = GetRandomColor();
        button3.BackColor = GetRandomColor();
        button4.BackColor = GetRandomColor();
    }
