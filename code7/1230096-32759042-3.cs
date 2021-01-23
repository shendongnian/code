    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace MyControls
    {
        public partial class MyUserControl : UserControl
        {
            private System.ComponentModel.IContainer components = null;
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            #region Component Designer generated code
            private void InitializeComponent()
            {
                this.button1 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(3, 15);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 23);
                this.button1.TabIndex = 0;
                this.button1.Text = "button1";
                this.button1.UseVisualStyleBackColor = true;
                // 
                // MyUserControl
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Controls.Add(this.button1);
                this.Name = "MyUserControl";
                this.ResumeLayout(false);
            }
            #endregion
            private System.Windows.Forms.Button button1;
            public MyUserControl()
            {
                InitializeComponent();
            }
    
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public Button MyButtonProperty
            {
                get
                {
                    return this.button1;
                }
                set
                {
                    value = this.button1;
                }
            }
        }
    }
