    ContentDialog contentDialog = new ContentDialog();
    contentDialog.Content = "Login Test";
    contentDialog.PrimaryButtonText = "Login";
    contentDialog.PrimaryButtonClick += async (s, args) =>
    {
        ContentDialogButtonClickDeferral deferral = args.GetDeferral();
    
        //Do Some Async Sign In Operation
        await Task.Delay(3000);  //Here I just wait 3 seconds
    
        deferral.Complete();
    };
    await contentDialog.ShowAsync();
