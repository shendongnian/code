        private void inputTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                consoleRichBox.Text += inputTextBox.Text + "\r\n";
                inputTextBox.Text = "";
                e.Handled = true;
            
            }
        }
