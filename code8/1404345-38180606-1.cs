    private void txtAddNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        char c = Convert.ToChar(e.Text);
        if (!Char.IsLetter(c))
        {
            // Put your Logic here according to requirement
            e.Handled = false;
        }
        else
        {
            // Put your Logic here according to requirement
            e.Handled = true;
        }
        base.OnPreviewTextInput(e);
    }
