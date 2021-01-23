    protected async override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
    {
        string caption = "Stop music and exit?";
        string message = "If you want to continue listen music while doing other stuff, please use Home key instead of Back key. Do you still want to exit?";
        MessageDialog msgDialog = new MessageDialog(message, caption);
        //OK Button
        UICommand okBtn = new UICommand("OK");
        msgDialog.Commands.Add(okBtn);
        //Cancel Button
         UICommand cancelBtn = new UICommand("Cancel");
         cancelBtn.Invoked = (s) => { e.Cancel = true; };
         msgDialog.Commands.Add(cancelBtn);
           //Show message
         await msgDialog.ShowAsync();
        base.OnBackKeyPress(e);
    }
