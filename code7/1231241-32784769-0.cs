    private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).MouseUp += SLMethod;
                }
            }
        }
        static void SLMethod(object sender, MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.SelectionLength = 0;
        }
