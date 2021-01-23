    private void button_ClickOld(object sender, RoutedEventArgs e)
    {
		SelectVerifyAndLog(TextBoxOld, UpdateOldLabel);
    }
	
    private void button_ClickNew(object sender, RoutedEventArgs e)
    {
		SelectVerifyAndLog(TextBoxNew, UpdateNewLabel);
    }
	
	void SelectVerifyAndLog(TextBox textBox, Action updateLabel)
	{
		textBox.Text = SelectCatalog();
        if (File.Exists(textBox + ConfigFilePath))
        {
            GetClientProperty(textBox.Text);
            updateLabel();
        }
        else
        {
            LogsTextBox.AppendText("\nWrong folder selected - Config file doesn't exist");
        }
	}
