    public class FlowForm2 : Form {
    
    	public FlowForm2() {
    		Button btn1 = new Button { Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", AutoSize = true };
    		Button btn2 = new Button { Text = "ABCD", AutoSize = true };
    		btn2.Anchor = AnchorStyles.Right;
    
    		FlowLayoutPanel p = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false };
    		p.Controls.Add(btn1); // if btn1 isn't added, then btn2 appears on the LEFT side
    		p.Controls.Add(btn2); // however, if btn1 is added, then btn2 is right justified with the right edge of btn2
    
    		Controls.Add(p);
    	}
    }
