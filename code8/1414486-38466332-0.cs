    private void Form1_Move(object sender, EventArgs e)
    {
        this.BackColor = this.Left/10 % 2 == 0 ? Color.Red : Color.Blue;
    }
    private void Form1_ResizeBegin(object sender, EventArgs e)
    {
        this.Text = this.Location.ToString(); 
    }
    private void Form1_ResizeEnd(object sender, EventArgs e)
    {
        this.Text = this.Location.ToString();
    }
