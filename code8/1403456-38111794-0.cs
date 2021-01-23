    using System.Windows.Forms;
    namespace ControlTest
    {
        public partial class MyUserControl : UserControl
        {
            public MyUserControl()
            {
                InitializeComponent();
            }
            private void InitializeComponent()
            {
                this.txtName = new System.Windows.Forms.TextBox();
                this.lblName = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // txtName
                // 
                this.txtName.Location = new System.Drawing.Point(107, 18);
                this.txtName.Name = "txtName";
                this.txtName.Size = new System.Drawing.Size(305, 20);
                this.txtName.TabIndex = 0;
                // 
                // lblName
                // 
                this.lblName.AutoSize = true;
                this.lblName.Location = new System.Drawing.Point(22, 23);
                this.lblName.Name = "lblName";
                this.lblName.Size = new System.Drawing.Size(35, 13);
                this.lblName.TabIndex = 1;
                this.lblName.Text = "Name";
                // 
                // MyUserControl
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Controls.Add(this.lblName);
                this.Controls.Add(this.txtName);
                this.Name = "MyUserControl";
                this.Size = new System.Drawing.Size(433, 57);
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            private System.Windows.Forms.TextBox txtName;
            private System.Windows.Forms.Label lblName;
        }
    }
