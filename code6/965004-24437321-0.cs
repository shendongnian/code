        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name == "button1")
            { 
                button1.BackColor = Color.Red;
                button2.BackColor = Color.Transparent;
            }
            else
            {
                button1.BackColor = Color.Transparent;
                button2.BackColor = Color.Red;
            }
        }
