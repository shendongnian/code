    SolidBrush brush;
    protected void btn_Click(object sender, EventArgs e)
    {
            brush = new SolidBrush(Color.Linen); //<--- set the brush color
            this.Refresh(); 
    }
    protected void myForm_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.FillRectangle(brush, 469, 132, 175, 28);
    }
