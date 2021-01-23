    public class TLPForm : Form {
    
    	TableLayoutPanel p = new TableLayoutPanel { Dock = DockStyle.Fill };
    
    	public TLPForm() {
    		var style = AnchorStyles.Top | AnchorStyles.Bottom;
    		Button btn1 = new Button { Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", AutoSize = true, AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink, Anchor = style };
    		Button btn2 = new Button { Text = "ABCD", AutoSize = true, AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink, Anchor = style };
    		Button btn3 = new Button { Text = "ABCD", AutoSize = true, AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink, Anchor = style };
    		p.Controls.Add(btn1, 0, 0);
    		p.Controls.Add(btn2, 1, 0);
    		p.Controls.Add(btn3, 2, 0);
    		p.Controls.Add(new Control(), 3, 0); // <-- takes up the rest of the space
    		Controls.Add(p);
    	}
    }
