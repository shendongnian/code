    public partial class SB : UserControl
	{
        //variables to remember sizes and locations
		Size parentSize = new Size(0,0);
		Point parentLocation = new Point (0,0);
        ......
        // we care only for horizontal changes by dragging the left border;
        // all others take care of themselves by Designer code
        public void SB_Resize(object sender, EventArgs e)
		{
			if (this.Parent == null)
				return;//we are still in the load process
			
			// get former values
			int fcsw = this.parentSize.Width;//former width
			int fclx = this.parentLocation.X;//former location
			Control control = (Control)sender;//this is our custom control
			
			// get present values
			int csw = control.Parent.Size.Width;//present width
			int clx = control.Parent.Location.X;//present location
			
			// both parent width and parent location have changed: it means we 
			// dragged the left border or one of the left corners
			if (csw != fcsw && clx != fclx)
			{
				int delta = clx - fclx;
				int lw = (int)this.tableLayoutPanel1.ColumnStyles[0].Width;
				int nlw = lw - delta;
				if (nlw > 0)
				{
					this.tableLayoutPanel1.ColumnStyles[0].Width -= delta;
				}
			}
			this.parentSize = control.Parent.Size;//always update it
			this.parentLocation = control.Parent.Location;
		}
        //contrary to documentation, the Resize event is not raised by moving
        //the form, so we have to override the Move event too, to update the
        //saved location
		private void SB_Move(object sender, EventArgs e)
		{
			if (this.Parent == null)
				return;//we are still in the load process
			this.parentSize = this.Parent.Size;//always update it
			this.parentLocation = this.Parent.Location;
		}
    }
