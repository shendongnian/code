    public class TC2 : TabControl {
    	public TC2() {
    		this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
    	}
    
    	protected override void OnPaint(PaintEventArgs e) {
    		base.OnPaint(e);
    		var g = e.Graphics;
    
    		TabPage currentTab = this.SelectedTab;
    		for (int i = 0; i < TabPages.Count; i++) {
    			TabPage tp = TabPages[i];
    			Rectangle r = GetTabRect(i);
    			Brush b = (tp == currentTab ? Brushes.LightSteelBlue : Brushes.LightGray);
    			g.FillRectangle(b, r);
    			TextRenderer.DrawText(g, tp.Text, tp.Font, r, tp.ForeColor);
    		}
    	}
    
    	protected override void OnPaintBackground(PaintEventArgs e) {
    		base.OnPaintBackground(e);
    	}
    }
