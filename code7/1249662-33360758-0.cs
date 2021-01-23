    public class RestoreForm : Form {
    
    	private const int SC_RESTORE = 0xF120;
    	private const int WM_SYSCOMMAND = 0x0112;
    	private const int WM_ACTIVATEAPP = 0x1C;
    
    	public RestoreForm() {
    		Button btn1 = new Button { Text = "ShowDialog(...)", AutoSize = true };
    		btn1.Click += btn1_Click;
    
    		Controls.Add(btn1);
    	}
    
    	protected override void WndProc(ref Message m) {
    		base.WndProc(ref m);
    		if (f2 != null) {
    			if (m.Msg == WM_ACTIVATEAPP) {
    				if (f2.WindowState == FormWindowState.Minimized) {
    					this.WindowState = FormWindowState.Minimized;
    				}
    			}
    			else if (m.Msg == WM_SYSCOMMAND) {
    				var w = m.WParam.ToInt32();
    				if (w == SC_RESTORE) {
    					f2.WindowState = FormWindowState.Normal;
    					//f2.Visible = true; // ignores staying on top of previous parent
    					f2.ShowDialog(this);
    				}
    			}
    		}
    	}
    
    	Form f2 = null;
    	void btn1_Click(object sender, EventArgs e) {
    		f2 = new Form { Text = "Child" };
    		f2.ShowDialog(this);
    	}
    }
