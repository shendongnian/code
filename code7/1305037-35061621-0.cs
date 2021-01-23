    private Regex _regex = new Regex(@"^C[AH]$");
    
    private void txtCaCh_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsControl(e.KeyChar))
            return;
        var txtBox = (TextBox)sender;
        if (txtBox.Text != null && _rolfRegex.IsMatch(txtBox.Text.ToUpper()))
        {
            // TODO now we have match, handle it
        }
    }
