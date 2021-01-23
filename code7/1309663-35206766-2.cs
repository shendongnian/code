    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                for (int i = 0; i < 3; i++)
                {
                    var x = new UserControl1 {Location = new Point(0, i*20)};
                    this.Controls.Add(x);
                }
            }
        }
    
        public  class UserControl1 : TextBox
        {
            public UserControl1()
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
                BackColor = Color.Transparent;
                TextChanged += UserControl2_OnTextChanged;
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                var backgroundBrush = new SolidBrush(Color.Transparent);
                Graphics g = e.Graphics;
                g.FillRectangle(backgroundBrush, 0, 0, this.Width, this.Height);          
                g.DrawString(Text, Font, new SolidBrush(ForeColor), new PointF(0,0), StringFormat.GenericDefault);
            }
    
            public void UserControl2_OnTextChanged(object sender, EventArgs e)
            {
                Invalidate();
            }
        }
    }
