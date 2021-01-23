    protected System.Drawing.Bitmap m_Bmp = new System.Drawing.Bitmap(yourWidth, yourHeight);
    protected System.Windows.Forms.PictureBox m_PictureBox = new System.Windows.Forms.PictureBox();
    protected Rectangle m_Rect;
    
    public MyWindow()
    {
      InitializeComponent();
      m_PictureBox.Image = m_Bmp;
      m_Rect= new Rectangle(0, 0, m_Bmp.Width, m_Bmp.Height);
      f_WindowsFormsHost.Child = m_PictureBox;
    }
    
    private void timer_Tick()
    {
      System.Drawing.Imaging.BitmapData bmpData = m_Bmp.LockBits(m_Rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, m_Bmp.PixelFormat);
      IntPtr ptr = bmpData.Scan0;
      //or use System.Runtime.InteropServices.Marshal.Copy(youData, 0, ptr, countBytes);
      Random r = new Random();
      unsafe {
        byte *data = (byte*)ptr;
        for (int i = 0; i < bmpData.Stride * m_Bmp.Height; ++i)
        {
          *data = (byte)r.Next(256);
          ++data;
        }
      }
      m_Bmp.UnlockBits(bmpData);
      m_PictureBox.Refresh();
    }
