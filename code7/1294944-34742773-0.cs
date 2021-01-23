        private bool state = false;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (state == false)
                {
                    MessageBox.Show("Enter a word");
                    state = true;
                }
                else if (state == true)
                {
                    MessageBox.Show("Hello");
                }
            }
        }
