        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var senderComboBox = (ComboBox)sender;
            this.globalTerminalPresenter.SelectedIndex = senderComboBox.SelectedIndex;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.globalTerminalPresenter.Do1();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.globalTerminalPresenter.Do2();
        }
