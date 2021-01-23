    private bool drawBorder;
    private void transparentControl1_MouseLeave(object sender, EventArgs e)
    {
        drawBorder = false;
        transparentControl1.Invalidate();
    }
    private void transparentControl1_MouseEnter(object sender, EventArgs e)
    {
        drawBorder = true;
        transparentControl1.Invalidate();
    }
    private void transparentControl1_Paint(object sender, PaintEventArgs e)
    {
        if(drawBorder)
        {
            using (var pen = new Pen(this.ForeColor, 5))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.transparentControl1.Width - 1, this.transparentControl1.Height - 1);
            }
        }
    }
    private void transparentControl1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Clicked");
    }
