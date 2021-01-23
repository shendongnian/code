        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Back || !allowedChar.Any(chr => chr == e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            e.Handled = false;
        }
