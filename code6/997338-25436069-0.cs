    public class Form3 : Form {
    
    	Panel iconPanel = new Panel() { BackColor = Color.RosyBrown, Size = new Size(200, 200) };
    	ToolTip changeIconTip = new ToolTip();
    	bool showingTip = false;
    
    	public Form3() {
    		Controls.Add(iconPanel);
    
    		iconPanel.MouseEnter += iconPanel_MouseEnter;
    		iconPanel.MouseLeave += iconPanel_MouseLeave;
    	}
    
    	void iconPanel_MouseLeave(object sender, EventArgs e) {
    		Rectangle iconPanelArea = new Rectangle(iconPanel.PointToScreen(new Point(0, 0)), iconPanel.Size);
    		Point c = Cursor.Position;
    		if (!iconPanelArea.Contains(c)) {
    			showingTip = false;
    			changeIconTip.Hide(iconPanel);
    			Cursor = Cursors.Default;
    		}
    	}
    
    	void iconPanel_MouseEnter(object sender, EventArgs e) {
    		Cursor = Cursors.Hand;
    		if (!showingTip) {
    			showingTip = true;
    			changeIconTip.Show("Choose image...", iconPanel, 2, 2, 4000);
    		}
    	}
    }
