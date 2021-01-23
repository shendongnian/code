    private void DrawText()
		{
			// Figure out any screen scaling needed			
			float fScale = ((float)GetSystemDpi(this.Handle) / 96f);
			Font myfont = new Font("whatever", 10f * fScale, FontStyle.Regular);
			using (Graphics g = this.CreateGraphics())
			{
				g.DrawString("My Custom Text", myfont, Brushes.Black, new PointF(0, 0));
			}		
		}
