    private void DrawScene(Graphics g)
    {
        g.Clear(Color.Black);
        g.DrawImage(myBitmap, 0, 0);
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        DrawScene(e.Graphics);
        DrawSomething(e.Graphics);
    }
