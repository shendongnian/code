        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Text = DateTime.Now.ToString();
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (textBox1.Text.Length == 1)
                    {
                        char tbChar = textBox1.Text[0];
                        if (tbChar >= '1' && tbChar <= '9')
                        {
                            MessageBox.Show("Correct");
                            label2.Text = tbChar.ToString();
                            // Clear textbox
                            textBox1.Text = "";
                            return;
                        }
                    }
                    MessageBox.Show("Your input is not a number from 1 - 9");
                    break;
            }
        }
