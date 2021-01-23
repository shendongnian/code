        private void clipboardUpdater_Tick(object sender, EventArgs e)
        {
            if (!clipboardSaveTextBox.Text.Contains(Clipboard.GetText()))
            {
                clipboardSaveTextBox.Text += "\n" + Clipboard.GetText();
            }
        }
