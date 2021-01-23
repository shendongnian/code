    private void button_ClickOld(object sender, RoutedEventArgs e)
    {
        ButtonHelper(TextBoxOld);
    }
    private void button_ClickNew(object sender, RoutedEventArgs e)
    {
        ButtonHelper(TextBoxNew);
    }
    void ButtonsHelper(TextBox textBox) {
        TextBoxNew.Text = SelectCatalog();
        if (File.Exists(textBox + ConfigFilePath))
        {
            GetClientProperty(textBox.Text);
            UpdateNewLabel();
        }
        else
        {
            LogsTextBox.AppendText("\nWrong folder selected - Config file doesn't exist");
        }
    }
