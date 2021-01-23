    using System;
    using System.Windows.Forms;
    
    public class OvalLabel : Label {
        protected override void OnResize(EventArgs e) {
            using (var path = new System.Drawing.Drawing2D.GraphicsPath()) {
                path.AddEllipse(0, 0, this.Width, this.Height);
                this.Region = new System.Drawing.Region(path);
            }
            base.OnResize(e);
        }
    }
