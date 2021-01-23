     private void plusButton_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    int count = 0;
                    textBox2.Text = count.ToString();
                }
                else
                {
                    int count = Convert.ToInt16(textBox2.Text);
                    ++count;
                    textBox2.Text = count.ToString();
                }
            }
        private void minusButton_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0" || string.IsNullOrEmpty(textBox2.Text))
            {
                //do nothing
            }
            else
            {
                int count = Convert.ToInt16(textBox2.Text);
                --count;
                textBox2.Text = count.ToString();
            }
        }
