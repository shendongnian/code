    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace ans
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
            private void Form2_Load(object sender, EventArgs e)
            {
                var uc = new UserControl2();
                uc.Location = new Point(0, 0);
                this.Controls.Add(uc);
                WindowState = FormWindowState.Maximized;
            }
        }
    }
