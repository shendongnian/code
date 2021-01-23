    public partial class MyControl : UserControl
    {
       Image buffer;
       public MyControl()
       {
          InitializeComponent();
       }
    
       protected override void OnLayout(LayoutEventArgs e)
       {
          if (buffer != null)
          {
             buffer.Dispose();
             buffer = null;
          }
          base.OnLayout(e);
    
          this.Invalidate();  // force a repaint after the layout has changed
       }
    
       protected override void OnPaint(PaintEventArgs e)
       {
          if (buffer == null)
          {
             buffer = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
    
             using (Graphics g = Graphics.FromImage(buffer))
             {
                //g.Clear(Color.Transparent);  // pointless
                g.FillRectangle(Brushes.White, ClientRectangle);
                using (Font f = new System.Drawing.Font("Segoe UI", 12, FontStyle.Regular))
                {
                   g.DrawString("Simple text 100", f, Brushes.Black, ClientRectangle);
                }
             }
          }
          e.Graphics.DrawImage(buffer, ClientRectangle);
          base.OnPaint(e);
       }
    }
