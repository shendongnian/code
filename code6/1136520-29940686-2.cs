    UserInfo info = new UserInfo();
    UserInfoForm form = new UserInfoForm(info);
    ModernDialog dialog = new ModernDialog
    {
        Title = "User edition",
        Content = form,
        Width = 300
    };
    Button btnOk = dialog.OkButton;
    ICommand originalCommand = btnOk.Command; //the original command should close the window so i keep it
    btnOk.Command = info.LoginCommand;
    info.LoginCommand.AttachCommand(originalCommand); //and attach it to my command
    dialog.Buttons = new[] { btnOk, dialog.CancelButton };
    dialog.ShowDialog();
