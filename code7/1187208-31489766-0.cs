        class FormA : Form {
        
            private const int WM_SYSCOMMAND = 0x0112;
            private const int SC_MINIMIZE = 0xF020;
        	private const int SC_RESTORE = 0xF120; 
        	protected override void WndProc(ref Message m) {
        		switch (m.Msg) {
        			case WM_SYSCOMMAND:
        				int command = m.WParam.ToInt32();
        				if (command == SC_RESTORE) {
        					this.FormBorderStyle = FormBorderStyle.Sizable;
        					this.ControlBox = true;
        				}
        			break;
        		}
        		base.WndProc(ref m);
        	}
        }
        
    [DllImport("user32.dll")]
    static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
    
    private const int AW_VER_POSITIVE = 0x00000004;
    private const int AW_VER_NEGATIVE = 0x00000008;
    private const int AW_SLIDE =        0x00040000;
    private const int AW_HIDE = 0x00010000;
    
        
        		[STAThread]
        		static void Main() {
        			Application.EnableVisualStyles();
        			Form f = new FormA();
        			f.ControlBox = false;
        			f.FormBorderStyle = FormBorderStyle.None;
        			
        			bool isMinimizing = false;
        			var mb = new Button { Text = "Min" };
        			mb.Click += delegate {
        				isMinimizing = true;
        				f.FormBorderStyle = FormBorderStyle.Sizable;
        				f.ControlBox = true;
        				f.WindowState = FormWindowState.Minimized;
        				f.FormBorderStyle = FormBorderStyle.None;
        				isMinimizing = false;
        				//AnimateWindow(f.Handle, 300, AW_SLIDE | AW_VER_POSITIVE | AW_HIDE);
        
        			};
        			f.SizeChanged += delegate {
        				if (isMinimizing)
        					return;
        				if (f.WindowState != FormWindowState.Minimized)
        					f.FormBorderStyle = FormBorderStyle.None;
        			};
        
        			f.Controls.Add(mb);
        			Application.Run(f);
            }
