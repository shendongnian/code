    using System;
    using System.Windows.Forms;
    
    namespace SampleApplication
    {
        public class MyForm:Form
        {
            public NotMyForm()
            {
                InitializeComponent();
            }
            public void InitializeComponent()
            {
                int i="x";
                textBox1 = new TextBox()
                textBox1.Text = "Hi"
                this.Controls.Add(textBox1)
            }
    
            private TextBox textBox1
        }
    }
