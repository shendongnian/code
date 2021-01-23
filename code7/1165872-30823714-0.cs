    List<Rectangle> _rectangles = new List<Rectangle>();
    private void button1_Click(object sender, EventArgs e)
    {
        locationX = locationX + 20;
        locationY = locationY + 20;
        var rectangle = new Rectangle(locationX, locationY, 50, 30));
        this._rectangles.Add(rectangle);
        this.Invalidate(); // force Redraw the form
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        foreach(var rectangle in this._rectangles)
        {
            e.Graphics.DrawRectangle(Pens.Black, rectangle);
        }
    }
