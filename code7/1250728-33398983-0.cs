    private void panel1_Paint(object sender, PaintEventArgs e) {
      using (Pen myPen = new Pen(Color.Black, 5)) {
        e.Graphics.Clear(Color.White);
        if (bCircle) {
          e.Graphics.DrawEllipse(myPen, x, y, 100, 100);
        } else if (bSquare) {
          e.Graphics.DrawRectangle(myPen, x, y, 100, 100);
        }
      }
    }
