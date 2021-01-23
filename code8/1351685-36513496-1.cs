        private void Form1_Load(object sender, EventArgs e)
        {
            _eventHolders.Add(new EventHolder<EventHandler>(h => textBox1.TextChanged += h, h => textBox1.TextChanged -= h, textBox1_TextChanged));
            _eventHolders.Add(new EventHolder<EventHandler>(h => numericUpDown1.ValueChanged += h, h => numericUpDown1.ValueChanged -= h, numericUpDown1_ValueChanged));
            _eventHolders.Add(new EventHolder<MouseEventHandler>(h => textBox2.MouseMove += h, h => textBox2.MouseMove -= h, textBox2_MouseMove));
            _eventHolders.ForEach(eh => eh.Attach());
        }
