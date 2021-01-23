    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace MyUserControls
    {
        public class StartButton : Button
        {
            public StartButton()
            {
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.BackColor = System.Drawing.Color.Green;
                this.TextAlign = System.Drawing.ContentAlignment.BottomLeft; 
                this.Size = new Size(100, 100); 
            }
            protected override void OnPaint(PaintEventArgs pevent)
            {
                this.UpdateRegion();
                base.OnPaint(pevent);
            }
            protected void UpdateRegion()
            {
                var path = new GraphicsPath();
                Point[] points =
                { 
                    new Point(ClientSize.Width / 2, 0), 
                    new Point(0, ClientSize.Height/4), 
                    new Point(0, ClientSize.Height), 
                    new Point(ClientSize.Width, ClientSize.Height)
                };
                path.AddPolygon(points);
                this.Region = new Region(path);
            }
        }
    }
