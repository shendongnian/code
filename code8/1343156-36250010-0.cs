    bool DrawImage = true;
    private void Form1_Load(object sender, EventArgs e)
    {
      Task.Delay(1000).ContinueWith((t) =>
      {
        DrawImage = false;
        Invalidate();
      });
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      if (DrawImage)
        e.Graphics.DrawImage(YOUR_IMAGE_HERE, 0, 0);
    }
