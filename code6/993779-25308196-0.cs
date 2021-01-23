    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    public class MyCrazyForm : Form
    {
       private static Size szFormSize = new Size(600, 600);
       private static Size szCaptionButton = SystemInformation.CaptionButtonSize;
       private static Rectangle rcMinimizeButton = new Rectangle(new Point(330, 130), szCaptionButton);
       private static Rectangle rcCloseButton = new Rectangle(new Point(rcMinimizeButton.X + szCaptionButton.Width + 3, rcMinimizeButton.Y), SystemInformation.CaptionButtonSize);
    
       public MyCrazyForm()
       {
       	  // Not necessary in this sample: the designer was not used.
          //InitializeComponent();
    
          // Force the form's size, and do not let it be changed.
          this.Size = szFormSize;
          this.MinimumSize = szFormSize;
          this.MaximumSize = szFormSize;
    
          // Do not show a standard title bar (since we can't see it anyway)!
          this.FormBorderStyle = FormBorderStyle.None;
    
          // Set up the irregular shape of the form.
          using (GraphicsPath path = new GraphicsPath())
          {
             path.AddEllipse(0, 0, 200, 200);
             path.AddEllipse(120, 120, 475, 475);
             this.Region = new Region(path);
          }
       }
    
       protected override void OnActivated(EventArgs e)
       {
          base.OnActivated(e);
    
          // Force a repaint on activation.
          this.Invalidate();
       }
    
       protected override void OnDeactivate(EventArgs e)
       {
          base.OnDeactivate(e);
    
          // Force a repaint on deactivation.
          this.Invalidate();
       }
    
       protected override void OnPaint(PaintEventArgs e)
       {
          base.OnPaint(e);
    
          // Draw the custom title bar ornamentation.
          if (this.Focused)
          {
             ControlPaint.DrawCaptionButton(e.Graphics, rcMinimizeButton, CaptionButton.Minimize, ButtonState.Normal);
             ControlPaint.DrawCaptionButton(e.Graphics, rcCloseButton, CaptionButton.Close, ButtonState.Normal);
          }
          else
          {
             ControlPaint.DrawCaptionButton(e.Graphics, rcMinimizeButton, CaptionButton.Minimize, ButtonState.Inactive);
             ControlPaint.DrawCaptionButton(e.Graphics, rcCloseButton, CaptionButton.Close, ButtonState.Inactive);
          }
       }
    
       private Point GetPointFromLParam(IntPtr lParam)
       {
          // Handle 64-bit builds, which we detect based on the size of a pointer.
          // Otherwise, this is functionally equivalent to the Win32 MAKEPOINTS macro.
          uint dw = unchecked(IntPtr.Size == 8 ? (uint)lParam.ToInt64() : (uint)lParam.ToInt32());
          return new Point(unchecked((short)dw), unchecked((short)(dw >> 16)));
       }
    
       protected override void WndProc(ref Message m)
       {
          const int WM_SYSCOMMAND = 0x112;
          const int WM_NCHITTEST = 0x84;
          const int WM_NCLBUTTONDOWN = 0xA1;
          const int HTCLIENT = 1;
          const int HTCAPTION = 2;
          const int HTMINBUTTON = 8;
          const int HTCLOSE = 20;
    
          // Provide additional handling for some important messages.
          switch (m.Msg)
          {
             case WM_NCHITTEST:
                {
                   base.WndProc(ref m);
    
                   Point ptClient = PointToClient(GetPointFromLParam(m.LParam));
                   if (rcMinimizeButton.Contains(ptClient))
                   {
                      m.Result = new IntPtr(HTMINBUTTON);
                   }
                   else if (rcCloseButton.Contains(ptClient))
                   {
                      m.Result = new IntPtr(HTCLOSE);
                   }
                   else if (m.Result.ToInt32() == HTCLIENT)
                   {
                      // Make the rest of the form's entire client area draggable
                      // by having it report itself as part of the caption region.
                      m.Result = new IntPtr(HTCAPTION);
                   }
    
                   return;
                }
             case WM_NCLBUTTONDOWN:
                {
                   base.WndProc(ref m);
    
                   if (m.WParam.ToInt32() == HTMINBUTTON)
                   {
                      this.WindowState = FormWindowState.Minimized;
                      m.Result = IntPtr.Zero;
                   }
                   else if (m.WParam.ToInt32() == HTCLOSE)
                   {
                      this.Close();
                      m.Result = IntPtr.Zero;
                   }
    
                   return;
                }
             case WM_SYSCOMMAND:
                {
                   // Setting the form's MaximizeBox property to false does *not* disable maximization
                   // behavior when the caption area is double-clicked.
                   // Since this window is fixed-size and does not support a "maximized" mode, and the
                   // entire client area is treated as part of the caption to enable dragging, we also
                   // need to ensure that double-click-to-maximize is disabled.
                   // NOTE: See documentation for WM_SYSCOMMAND for explanation of the magic value 0xFFF0!
                   const int SC_MAXIMIZE = 0xF030;
                   if ((m.WParam.ToInt32() & 0xFFF0) == SC_MAXIMIZE)
                   {
                      m.Result = IntPtr.Zero;
                   }
                   else
                   {
                      base.WndProc(ref m);
                   }
                   return;
                }
          }
          base.WndProc(ref m);
       }
    }
