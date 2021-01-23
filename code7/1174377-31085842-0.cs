    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!Regex.IsMatch(e.KeyChar.ToString(), @"\p{IsArabic}")
            && !string.IsNullOrWhiteSpace(e.KeyChar.ToString()))
            e.Handled = true;
    }
