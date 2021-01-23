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
            }
        }
    }
