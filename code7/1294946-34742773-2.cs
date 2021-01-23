        private bool State = false;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (State == false)
                {
                    MessageBox.Show("Enter a word");
                    State = true;
                }
                else if (State == true)
                {
                    MessageBox.Show("Hello");
                    State = false;
                }
            }
        }
