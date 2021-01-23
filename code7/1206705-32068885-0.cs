    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string cardno = TextBox1.Text;
        var list = Enumerable
            .Range(0, cardno.Length / 4)
            .Select(i => cardno.Substring(i * 4, 4))
            .ToList();
        var resl = string.Join("-", list);
        TextBox1.Text = resl;
    }
