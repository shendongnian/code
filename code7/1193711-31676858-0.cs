    private void txtDicountSettlement_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9-]+");
        e.Handled = regex.IsMatch(e.Text);
    }
