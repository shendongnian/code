    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace GlobalMouseEvents
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             GlobalMouseHandler gmh = new GlobalMouseHandler();
             gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
             Application.AddMessageFilter(gmh);
    
             InitializeComponent();
          }
    
          void gmh_TheMouseMoved()
          {
             Point cur_pos = System.Windows.Forms.Cursor.Position;
             System.Console.WriteLine(cur_pos);
          }
       }
    
       public delegate void MouseMovedEvent();
    
       public class GlobalMouseHandler : IMessageFilter
       {
            private const int WM_MOUSEMOVE = 0x0200;
            private System.Drawing.Point previousMousePosition = new System.Drawing.Point();
            public static event EventHandler<MouseEventArgs> MouseMovedEvent = delegate { };
    
            #region IMessageFilter Members
    
            public bool PreFilterMessage(ref System.Windows.Forms.Message m)
            {
                if (m.Msg == WM_MOUSEMOVE)
                {
                    System.Drawing.Point currentMousePoint = Control.MousePosition;
                    // Prevent event from firing twice.
                    if (previousMousePosition == new System.Drawing.Point(0, 0))
                    { return; }
    
                    if (previousMousePosition != currentMousePoint)
                    {
                        previousMousePosition = currentMousePoint;
                        MouseMovedEvent(this, new MouseEventArgs(MouseButtons.None, 0, currentMousePoint.X, currentMousePoint.Y, 0));
                    }
                }
                // Always allow message to continue to the next filter control
                return false;
            }
    
            #endregion
        }
    }
