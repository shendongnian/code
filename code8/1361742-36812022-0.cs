    private void Form1_Paint(object sender, PaintEventArgs e)
    {
    	int counter = 0;
    	Point start = new Point(10, 50);
    	Point end = new Point(510, 50);
    
    	using (Pen thickpen = new Pen(Color.Black, 2f))
    	using (Pen thinpen = new Pen(Color.Black, 1f))
    	{
    		e.Graphics.DrawLine(thinpen, start, end);
    
    		for (int i = 0; i < 501; i += 5)
    		{
    			if (counter % 5 == 0)
    			{
    				e.Graphics.DrawLine(thickpen, start.X + i, start.Y, start.X + i, start.Y - 5);
    			}
    			else
    			{
    				e.Graphics.DrawLine(thinpen, start.X + i, start.Y, start.X + i, start.Y - 3);
    			}
    
    			counter++;
    		}
    	}
    }
