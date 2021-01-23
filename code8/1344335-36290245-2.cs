        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control) return; // Check if ctrl is pressed
            var key = (char) e.KeyValue; // ASCII to char
            if (char.IsDigit(key) || char.IsControl(key) || char.IsWhiteSpace(key)) return; // Check if "key" is a number
            MessageBox.Show("You have entered a symbol! Please enter a number"); 
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1); // Remove last element
            textBox1.SelectionStart = textBox1.Text.Length; // Return to initial position
        }
