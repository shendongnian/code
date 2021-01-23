    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace DateCounter
    {
        public partial class PaintDrawingControl : UserControl
        {
            public static string texttodraw;
            public static Font font;
    
            public PaintDrawingControl()
            {
                InitializeComponent();
            }
    
            private void PaintDrawingControl_Load(object sender, EventArgs e)
            {
    
            }
    
            private void PaintDrawingControl_Paint(object sender, PaintEventArgs e)
            {
                if (DesignMode) return;
    
                e.Graphics.DrawString(texttodraw,
                font, Brushes.Black, 10, 10);
            }
        }
    }
