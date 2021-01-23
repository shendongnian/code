    using System.Windows.Forms;
    namespace ControlTest
    {
        public partial class Form1 : Form
        {
            private MyUserControl myUserControl1;
            public Form1()
            {
                InitializeComponent();
                this.myUserControl1.Location = new System.Drawing.Point(12, 12);
                this.myUserControl1.Name = "myUserControl1";
                this.myUserControl1.Size = new System.Drawing.Size(433, 57);
                this.myUserControl1.TabIndex = 0;
            }
        }
    }
