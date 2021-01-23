    private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.MyFunction(this.TextBox1.Text);
            }
        }
