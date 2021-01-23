    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int changeLenght, position;
        double dummy;
        if (!String.IsNullOrWhiteSpace(textBox1.Text) && !double.TryParse(textBox1.Text, out dummy))
        {
            ...
        }
    }
