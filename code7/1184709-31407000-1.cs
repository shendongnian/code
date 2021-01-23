    private void tb_Surface_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        var patten = @"^(0(\.\d*)?|1(\.0*)?)$";
        Regex regex = new Regex(patten);
        e.Handled = !regex.IsMatch(e.Text);
        // e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
    }
