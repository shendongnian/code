            private TextBox SelectedTextBox { get; set; }
        private void NumericButton_Click(object sender, EventArgs e)
        {
            var clickedBox = sender as Button;
            if (clickedBox != null)
            {
                this.SelectedTextBox.Text += clickedBox.Text;
            }
        }
        private void TextBox_Click(object sender, EventArgs e)
        {
            var thisBox = sender as TextBox;
            if (thisBox == null)
            {
                return;
            }
            this.SelectedTextBox = thisBox;
        }
