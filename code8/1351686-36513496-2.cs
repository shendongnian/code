        private void textBox1_TextChanged(object sender, EventArgs e)
        { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = numericUpDown1.Value.ToString();
        }
        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {
            _eventHolders.ForEach(eh => eh.Detach());
        }
