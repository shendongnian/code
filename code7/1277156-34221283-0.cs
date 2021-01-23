        const int MAX_CHARS = 10;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] sTextArray = textBox1.Text.Split( new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries );
            int nLines = sTextArray.Length;
            string sLastLine = sTextArray[nLines -1];
            if (sLastLine.Length > MAX_CHARS)
            {
                int nTextLen = textBox1.Text.Length;
                string sText = textBox1.Text.Substring(0, nTextLen - 1) + Environment.NewLine + textBox1.Text[nTextLen - 1];
                textBox1.Text = sText;
                textBox1.SelectedText = "";
                textBox1.Select(nTextLen +2, 0);
            }
        }
