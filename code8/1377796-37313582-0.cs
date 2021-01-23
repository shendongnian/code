    TextBlock yourTextBox = yourDataTemplate.FindName("tblAlertId", contentPresenter) 
    as TextBlock;
    if (yourTextBox != null)
    {
        alertId = Convert.ToInt32(item.Text);
    executeAlertClickCommand(ConsoleSettingsModel.GetInstance().SettingsCommandsData.AlertCommand, alertId);
    }
