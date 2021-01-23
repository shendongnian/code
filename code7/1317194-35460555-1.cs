    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ans
    {
        public partial class UserControl2 : UserControl
        {
            public UserControl2()
            {
                InitializeComponent();
            }
    
            private void UserControl2_Load(object sender, EventArgs e)
            {
                this.BackColor = Color.Aqua;
                if (this.ParentForm != null)
                {
                    this.Size = this.ParentForm.Size;
                    this.ParentForm.Resize += ParentForm_Resize;
                }
            }
    
            private void ParentForm_Resize(object sender, EventArgs e)
            {
                this.Size = ((Form)sender).Size;
            }
        }
    }
