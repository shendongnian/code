    class FormTab : Form {
    
    	public FormTab() {
    		TabControl tc = new TabControl { Dock = DockStyle.Fill };
    		TabPage page = new TabPage();
    		var tlp1 = new TableLayoutPanel();
    		tlp1.Dock = DockStyle.Top;
    		tlp1.AutoSize = true;
    		tlp1.BackColor = Color.Bisque;
    
    		var tlp2 = new TableLayoutPanel();
    		tlp2.Dock = DockStyle.Bottom;
    		tlp2.AutoSize = true;
    		tlp2.BackColor = Color.DarkSeaGreen;
    
    		VFLP p = new VFLP();
    		p.SuspendLayout();
    		p.Controls.Add(tlp2);
    		p.Controls.Add(tlp1);
    		page.Controls.Add(p);
    		//page.Controls.Add(tlp2);
    		//page.Controls.Add(tlp1);
    
    		for (var i = 0; i < 10; i++) {
    			tlp1.Controls.Add(new TextBox() {
    				Text = string.Format("page1. {0}", i)
    			});
    
    			tlp2.Controls.Add(new TextBox() {
    				Text = string.Format("page2. {0}", i)
    			});
    		}
    
    		this.DoubleClick += delegate {
    			Size s = page.GetPreferredSize(Size.Empty);
    			int bp = 1;
    		};
    
    		tc.TabPages.Add(page);
    		page.AutoScroll = true;
    		Controls.Add(tc);
    		p.ResumeLayout(true);
    	}
    
    	class VFLP : FlowLayoutPanel {
    
    		public VFLP() {
    			this.BackColor = Color.AliceBlue;
    			WrapContents = false;
    			FlowDirection = FlowDirection.TopDown;
    			AutoSize = true;
    			AutoSizeMode = AutoSizeMode.GrowAndShrink;
    		}
    
    		public override Size GetPreferredSize(Size proposedSize) {
    			Size s = base.GetPreferredSize(proposedSize);
    			Size s2 = Size.Empty;
    			foreach (Control c in Controls) {
    				Size s3 = c.GetPreferredSize(Size.Empty);
    				Padding m = c.Margin;
    				s2.Height += s3.Height + m.Vertical;
    				int w = s3.Width + m.Horizontal;
    				if (w > s2.Width)
    					s2.Width = w;
    			}
    
    			return s2;
    		}
    	}
    }
