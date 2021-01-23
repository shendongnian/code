    public class DrawPanel : Panel {
    
    	public Rectangle rect = new Rectangle(0, 0, 200, 100);
    	int offsetX = 0;
    	int offsetY = 0;
    	bool grabbing = false;
    
    	public DrawPanel() {
    		Dock = DockStyle.Fill;
    		AutoScroll = true;
    	}
    
    	protected override void OnMouseDown(MouseEventArgs e) {
    		base.OnMouseDown(e);
    		var p = e.Location;
    		if (rect.Contains(p)) {
    			grabbing = true;
    			offsetX = rect.X - p.X;
    			offsetY = rect.Y - p.Y;
    		}
    	}
    
    	protected override void OnMouseUp(MouseEventArgs e) {
    		base.OnMouseUp(e);
    		grabbing = false;
    	}
    
    	protected override void OnMouseMove(MouseEventArgs e) {
    		base.OnMouseMove(e);
    		if (grabbing) {
    			var p = e.Location;
    			rect.Location = new Point(p.X + offsetX, p.Y + offsetY);
    			Invalidate();
    
    			int right = rect.X + rect.Width;
    			int bottom = rect.Y + rect.Height;
    
    			if (right > Width || bottom > Height) {
    				this.AutoScrollMinSize = new Size(right + 1, bottom + 1);
    			}
    		}
    	}
    
    	protected override void OnScroll(ScrollEventArgs se) {
    		base.OnScroll(se);
    		Invalidate();
    	}
    
    	protected override void OnPaint(PaintEventArgs e) {
    		base.OnPaint(e);
    
    		var g = e.Graphics;
    		var p = AutoScrollPosition;
    		Rectangle r = rect;
    		r.X += p.X;
    		r.Y += p.Y;
    		g.DrawRectangle(Pens.Red, r);
    	}
    
    }
