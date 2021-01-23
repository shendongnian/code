        private void clipboardUpdater_Tick(object sender, EventArgs e)
        {
            if (!richTextBox1.Text.Contains(Clipboard.GetText()))
            {
                richTextBox1.Text += Clipboard.GetText();
            }
        }
