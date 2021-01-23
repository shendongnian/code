    Task.Run<DialogResult>(() =>
    {
        return MessageBox.Show("Message", "Title", MessageBoxButtons.OKCancel);
    }).ContinueWith((result) =>
    {
        var dialogResult= result.Result;
        if(dialogResult== System.Windows.Forms.DialogResult.OK)
            MessageBox.Show("OK Clicked");
        else
            MessageBox.Show("Cancel Clicked");
    });
