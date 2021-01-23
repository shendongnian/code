    IEnumerable<TextBox> textBoxCollection = this.Controls.OfType<TextBox>();
            foreach (TextBox box in textBoxCollection)
            {
                if (!string.IsNullOrWhiteSpace(box.Text))
                {
                    MessageBox.Show(box.Text);   
                }
            }
