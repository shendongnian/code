    private void txtAddNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        char c = Convert.ToChar(e.Text);
        if (!Char.IsLetter(c))
            e.Handled = false;
        else
            e.Handled = true;
        base.OnPreviewTextInput(e);
    }
