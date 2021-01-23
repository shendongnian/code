           private Queue<string> _lines;
        private void button1_Click(object sender, EventArgs e)
        {
            _lines = new Queue<string>(System.IO.File.ReadAllLines(myFilePath));
            textBox1.Text = string.Empty;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_lines.Any())
                textBox1.Text += _lines.Dequeue() + Environment.NewLine;
            else
                timer1.Stop();
        }
