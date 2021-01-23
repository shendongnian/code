    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;
    
    namespace InfinityLabel
    {
        public partial class InfinityLabel : Label
        {
            public InfinityLabel()
            {
                InitializeComponent();
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                Rectangle rect = new Rectangle(0, 0, Width, Height);
                LinearGradientBrush brush =
                    new LinearGradientBrush(
                        rect, 
                        Color.FromArgb(255, ForeColor),
                        Color.FromArgb(60, ForeColor), 
                        90f);
                e.Graphics.DrawString(Text, Font, brush, rect);
            }
        }
    }
