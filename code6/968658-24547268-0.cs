     foreach (Control child in this.Controls)
        {
            TextBox textBox = child as TextBox;
            if (textBox != null)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("Text box can't be empty");
                }
            }
        }
