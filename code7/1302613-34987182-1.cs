	public popUpForm(Rectangle[] images)
	{
       Pen pen = new Pen(Color.Red, 2);
       using (var g = pictureBox.CreateGraphics())
         foreach (Rectangle rect in images)
           g.DrawRectangle(pen, rect);
	}
