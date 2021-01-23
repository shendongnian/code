    public class CustomToolTip : ToolTip {
    	public CustomToolTip() {
    		this.BackColor = Color.FromArgb(127, 255, 0, 0);
    		this.OwnerDraw = true;
    		this.Popup += new PopupEventHandler(this.OnPopup);
    		this.Draw += new DrawToolTipEventHandler(this.OnDraw);
    	}
    
    	private void OnPopup(Object sender, PopupEventArgs e) {
    		e.ToolTipSize = new Size(200, 100);
    		var window = typeof(ToolTip).GetField("window", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this) as NativeWindow;
    
    		var Handle = window.Handle;
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) ^ WS_EX_LAYERED);
            SetLayeredWindowAttributes(Handle, 0, 128, LWA_ALPHA);
    	}
    
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;
    
    	[DllImport("user32.dll")]
    	static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey,byte bAlpha, uint dwFlags);
    	[DllImport("user32.dll", SetLastError=true)]
    	static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    	[DllImport("user32.dll")]
    	static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    
    	private void OnDraw(object sender, DrawToolTipEventArgs e) {
    		e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);
    		e.Graphics.DrawString(e.ToolTipText, e.Font, Brushes.Black, e.Bounds);
    	}
    }
