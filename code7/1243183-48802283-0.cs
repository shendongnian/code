    string prev_text = string.Empty;
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            int MaxLineCount = 5;
            if (textBox1.LineCount > MaxLineCount)
            {
                int index = textBox1.CaretIndex;
                textBox1.Text = prev_text;
                textBox1.CaretIndex = index;
            }
            else
            {
                prev_text = textBox1.Text;
            }
        }
