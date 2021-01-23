    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WinForm
    {
        public partial class frmMain : Form
        {
            private Point centerPoint;              // circle center point
            private double radius;                  // circle radius (R)
            private double radius2;                 // R^2
    
            /// <summary>
            /// form constructor
            /// </summary>
            public frmMain()
            {
                InitializeComponent();
    
                this.Size = new Size(640, 480);
                this.Load += delegate
                {
                    PictureBox pb = new PictureBox();
    
                    int size = Math.Min(this.ClientSize.Width, this.ClientSize.Height) - 20;
    
                    pb.Location = new Point((this.ClientSize.Width - size) / 2, (this.ClientSize.Height - size) / 2);
                    pb.Size = new Size(size, size);
                    pb.Paint += (s, e) =>
                    {
                        var g = e.Graphics;
                        var rect = new Rectangle(Point.Empty, pb.Size);
    
                        g.FillEllipse(Brushes.ForestGreen, rect);
                        g.DrawEllipse(Pens.Navy, rect);
    
                        // base cursor clip
                        this.Cursor = new Cursor(Cursor.Current.Handle);
                        Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
                        Cursor.Clip = pb.RectangleToScreen(rect);
                    };
    
                    this.Controls.Add(pb);
    
                    // setup circle parameters
                    centerPoint = new Point(pb.Left + pb.Width / 2, pb.Top + pb.Height / 2);
                    radius = (double)size * 0.5;
                    radius2 = radius * radius;
    
    
                    // bind to events
                    pb.MouseMove += Mouse_Move;
                    this.MouseMove += Mouse_Move;
                };
            }
    
            private void Mouse_Move(object sender, MouseEventArgs e)
            {
                // client mouse point
                var point = this.PointToClient(((Control)sender).PointToScreen(e.Location));
    
                // circle center point
                double cx = centerPoint.X;
                double cy = centerPoint.Y;
    
                // circle center offset
                double sx = point.X - cx;
                double sy = point.Y - cy;
    
                // direction angle
                double alpha = Math.Atan2(-sy, sx);
                this.Text = string.Format("{0} {1} {2:0.00} rad, {3:0} degrees", sx, sy, alpha, 180.0 * alpha / Math.PI);
    
                // range to center
                double range = sx * sx + sy * sy;
                if (range > radius2)
                {
                    int px = (int)Math.Round(cx + Math.Cos(alpha) * radius);
                    int py = (int)Math.Round(cy - Math.Sin(alpha) * radius);
                    Cursor.Position = this.PointToScreen(new Point(px, py));
                }
            }
        }
    }
