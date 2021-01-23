    using System
    using System.Collections.Generic
    using System.Drawing
    using System.Windows.Forms
    namespace Sample
    {
        public class Form1:Form
        {
            public Form111111()
            {
                NotDefinedFunction()
                InitializeComponent()
            }
            public void InitializeComponent()
            {
                int i = "xxxxxxxxxx"
                this.textBox1 = new System.Windows.Forms.TextBox()
                this.SuspendLayout()
                // 
                // textBox1
                // 
                this.textBox1.Location = new System.Drawing.Point(0, 0)
                this.textBox1.Name = "textBox1"
                this.textBox1.Text = "text of text box 1";
                // 
                // Form1
                // 
                this.Controls.Add(this.textBox1)
                this.Name = "Form1"
                this.Text = "Form1"
                this.Size= new Size(250,100)
                this.ResumeLayout(false)
                this.PerformLayout()
            }
            private TextBox textBox1
        }
    }
