        private void Calculator_Load(object sender, EventArgs e)
        {
             List<Button> buttons = new List<Button>();
             for (int i = 0; i < 10; i++)
             {
                 Button btn = new Button();
                 btn.Click += Program_Click;
                 btn.Text = i.ToString();
                 buttons.Add(btn);
             }
        }
        void Program_Click(object sender, EventArgs e)
        {
            txtNumPad.Text = txtNumPad.Text + ((Button)sender).Text;
        }
