    private void DrawResistor(PaintEventArgs e)
	{
		Graphics g = e.Graphics;
		SolidBrush brs;
		//Første farve
		g.DrawLine(Pens.Black, 130, 35, 130, 109);
		g.DrawLine(Pens.Black, 140, 35, 140, 109);
	    using (brs = new SolidBrush(this.Controls.Find(Farver[0], false)[0].BackColor))
	    {
	        g.FillRectangle(brs, 131, 35, 9, 75);
	    }
        //Anden farve
        g.DrawLine(Pens.Black, 160, 44, 160, 100);
        g.DrawLine(Pens.Black, 170, 44, 170, 100);
        using (brs = new SolidBrush(this.Controls.Find(Farver[1], false)[0].BackColor))
	    {
	        g.FillRectangle(brs, 161, 44, 9, 56);
	    }
	    //Tredje farve	
		if (comboBox1.SelectedIndex != 0)
		{
			g.DrawLine(Pens.Black, 190, 44, 190, 100);
			g.DrawLine(Pens.Black, 200, 44, 200, 100);
		    using (brs = new SolidBrush(this.Controls.Find(Farver[2], false)[0].BackColor))
		    {
		        g.FillRectangle(brs, 191, 44, 9, 56);
		    }
		}
		//Fjerde farve
		g.DrawLine(Pens.Black, 220, 44, 220, 100);
		g.DrawLine(Pens.Black, 230, 44, 230, 100);
	    using (brs = new SolidBrush(this.Controls.Find(Farver[3], false)[0].BackColor))
	    {
	        g.FillRectangle(brs, 221, 44, 9, 56);
	    }
	    //Femte farve
		g.DrawLine(Pens.Black, 265, 35, 265, 109);
		g.DrawLine(Pens.Black, 280, 35, 280, 109);
	    using (brs = new SolidBrush(this.Controls.Find(Farver[4], false)[0].BackColor))
	    {
	        g.FillRectangle(brs, 266, 35, 14, 75);
	    }
	    //Sjette farve
		if (comboBox1.SelectedIndex == 2)
		{
			g.DrawLine(Pens.Black, 293, 35, 293, 109);
			g.DrawLine(Pens.Black, 303, 35, 303, 109);
		    using (brs = new SolidBrush(this.Controls.Find(Farver[5], false)[0].BackColor))
		    {
		        g.FillRectangle(brs, 294, 35, 9, 75);
		    }
		}
	}
