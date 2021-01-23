    public partial class Form1 : Form
    {
    	[DllImport("Dwmapi.dll")]
    	static extern int DwmSetIconicThumbnail(IntPtr hWnd, IntPtr hbmp, uint dwSITFlags);
    
    	[DllImport("Dwmapi.dll")]
    	static extern int DwmSetWindowAttribute(IntPtr hWnd, uint dwAttribute, IntPtr pvAttribute, uint cbAttribute);
    
    	const uint WM_DWMSENDICONICTHUMBNAIL = 0x0323;
    	const uint DWMWA_FORCE_ICONIC_REPRESENTATION = 7;
    	const uint DWMWA_HAS_ICONIC_BITMAP = 10;
    
    	Size thumbSize = new Size(30, 30);
    	Bitmap thumbImage = new Bitmap(30, 30);
    	object sync = new object();
    
    	public Form1()
    	{
    		InitializeComponent();
    		using (Graphics g = Graphics.FromImage(this.thumbImage))
    		{
    			g.Clear(Color.Blue);
    			g.DrawRectangle(Pens.Black, new Rectangle(new Point(0, 0), this.thumbSize));
    		}
    		this.HandleCreated += Form1_HandleCreated;
    	}
    	protected override void WndProc(ref Message m)
    	{
    		if (m.Msg == WM_DWMSENDICONICTHUMBNAIL)
    		{
    			lock (this.sync)
    			{
    				int x = (int)((m.LParam.ToInt32() >> 16) & 0xffff);
    				int y = (int)(m.LParam.ToInt32() & 0xffff);
    				if (this.thumbSize != new Size(x, y))
    				{
    					this.thumbSize = new Size(x, y);
    					this.UpdateBitmap();
    				}
    				DwmSetIconicThumbnail(this.Handle, thumbImage.GetHbitmap(), 0);
    			}
    		}
    		base.WndProc(ref m);
    	}
    
    	void UpdateBitmap()
    	{
    		lock (this.sync)
    		{
    			this.thumbImage = new Bitmap(this.thumbSize.Width, this.thumbSize.Height);
    			using (Graphics g = Graphics.FromImage(this.thumbImage))
    			{
    				g.Clear(Color.Blue);
    				g.DrawRectangle(Pens.Black, new Rectangle(new Point(0, 0), this.thumbSize));
    				//or: g.DrawImage() with stretching specified.
    			}
    		}
    	}
    
    	private void Form1_HandleCreated(object sender, EventArgs e)
    	{
    		IntPtr val = Marshal.AllocHGlobal(4);
    		Marshal.WriteInt32(val, 1);
    		DwmSetWindowAttribute(this.Handle, DWMWA_FORCE_ICONIC_REPRESENTATION, val, 4);
    		DwmSetWindowAttribute(this.Handle, DWMWA_HAS_ICONIC_BITMAP, val, 4);
    		Marshal.FreeHGlobal(val);
    	}
    }
