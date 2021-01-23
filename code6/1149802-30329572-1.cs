	private void pnlButtons_Click(object sender, EventArgs e)
	{
		Point ptClick = Control.MousePosition;
		foreach (Control cntrl in pnlButtons.Controls)
		{
			// Make sure the control is visible!
			if (cntrl.Visible)
			{
				// Click close to control?
				if ((ptClick.X > (cntrl.Left - 5)) &&
					(ptClick.X < (cntrl.Right + 5)) &&
					(ptClick.Y > (cntrl.Top - 5)) &&
					(ptClick.Y < (cntrl.Bottom + 5)))
				{
					handleClick (cntrl);
				}
			}
		}
	}
	
	private void handleClick(Control c)
	{
	    if (c == button1)
		{
		    // handle button1 click, e.g. by calling its `Click` handler
		}
		else if (c == picureBox1)
		{
		    // handle pictureBox1 click
		}
		// et cetera
	}
