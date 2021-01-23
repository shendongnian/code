        private void Init()
        {
            button.Click += Button_Click;//you button
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            panel.Controls.Remove(button);// your control containing the button...
            flowLayoutPanel.Controls.Add(button);// your flowLayoutPanel
        }
