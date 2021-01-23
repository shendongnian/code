    private void button1_Click(object sender, EventArgs e)
    {
    	panel1.Width = 400;
    	panel1.Height = 50;
                
    	using (Graphics g = this.panel1.CreateGraphics()) 
    	{
    		g.Clear(Color.Black);
    		Pen pen = new Pen(Color.Red, 2);               
    		for (int i = 0; i <= 50;i++ )
    		{
    			g.DrawRectangle(pen, 0, 0, 400, i);                    
    			Thread.Sleep(100);
    		}                   
    		pen.Dispose();
    	}
    }
