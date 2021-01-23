		private bool blnButtonDown = false;
		private void button_Paint(object sender, PaintEventArgs e)
		{
			if (blnButtonDown == false)
			{
				ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Button).ClientRectangle,
					System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
					System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
					System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
					System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
			}
			else
			{
				ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Button).ClientRectangle,
					System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
					System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
					System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
					System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset);
			}
		}
		private void button_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			blnButtonDown = true;
			(sender as System.Windows.Forms.Button).Invalidate();
		}
		private void button_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			blnButtonDown = false;
			(sender as System.Windows.Forms.Button).Invalidate();
		}
