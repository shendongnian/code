    private void Hostname_TextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateLabel(Hostname, HostnameLabel);
    }
    
    private void UpdateLabel(TextBox textBox, Label label)
    {
        label.Visibility = String.IsNullOrWhiteSpace(textBox.Text) ? Visibility.Visible : Visibility.Hidden;
    }
