    // Only allows "Persian characters" and "Space".
    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!Regex.IsMatch(e.KeyChar.ToString(), @"\p{IsArabic}")
            && !string.IsNullOrWhiteSpace(e.KeyChar.ToString()))
            e.Handled = true;
    }
    // Only allows "Persian characters", "Space" and "Numbers".
    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!Regex.IsMatch(e.KeyChar.ToString(), @"\p{IsArabic}")
            && !string.IsNullOrWhiteSpace(e.KeyChar.ToString())
            && !char.IsDigit(e.KeyChar))
            e.Handled = true;
    }
