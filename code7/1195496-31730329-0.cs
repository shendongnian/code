    private List<Rectangle> rectangles = new List<Rectangle>();
    ...
    private void button1_Click(object sender, EventArgs e)
    {
        rectangles.Add(new Rectangle(x, y, width, height));
        panel1.Invalidate(); // cause the paint event to be called
        // todo increment x/y
    }
