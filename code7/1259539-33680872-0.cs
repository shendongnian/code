    private void NumericButton_Click(object sender, EventArgs e)
    {
        var clickedBox = sender as TextBox;
        if (clickedBox != null)
        {
            this.textBox1.Text = clickedBox.Text;
        }
    }
