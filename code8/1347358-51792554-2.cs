    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Extensions
    {
        public static class MyExtensions
        {
    
            public static void Init(this TextBox textBox, string prompt)
            {
                textBox.Text = prompt;
                bool wma = true;
                textBox.ForeColor = Color.Gray;
                textBox.GotFocus += (source, ex) =>
                {
                    if (wma)
                    {
                        wma = false;
                        textBox.Text = "";
                        textBox.ForeColor = Color.Black;
                    }
                };
    
                textBox.LostFocus += (source, ex) =>
                {
                    if (!wma && string.IsNullOrEmpty(textBox.Text))
                    {
                        wma = true;
                        textBox.Text = prompt;
                        textBox.ForeColor = Color.Gray;
                    }
                };
    
    
                textBox.TextChanged += (source, ex) =>
                {
                    if (((TextBox)source).Text.Length > 0)
                    {
                        textBox.ForeColor = Color.Black;
                    }
                };
            }
        }
    }
