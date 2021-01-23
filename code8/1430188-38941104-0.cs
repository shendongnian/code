    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
            }
            private void UserControl1_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawEllipse(Pens.Blue, 0, 0, this.Width, this.Height);
                e.Graphics.DrawString("90", this.Font, Brushes.Black, new PointF(0, 0));
                e.Graphics.DrawLine(Pens.Red, 0,0, this.Width, this.Height );
            }
        }
    }
